using System;

namespace LabWork
{
    public class Rectangle
    {
        private double _b1;
        private double _a1;
        private double _b2;
        private double _a2;

        public Rectangle() { }

        public Rectangle(double b1, double a1, double b2, double a2)
        {
            SetCoefficients(b1, a1, b2, a2);
        }

        public virtual void SetCoefficients(double b1, double a1, double b2, double a2)
        {
            _b1 = Math.Min(b1, a1);
            _a1 = Math.Max(b1, a1);
            _b2 = Math.Min(b2, a2);
            _a2 = Math.Max(b2, a2);
        }

        public virtual void DisplayCoefficients()
        {
            Console.WriteLine($"Rectangle: {_b1} <= x1 <= {_a1}, {_b2} <= x2 <= {_a2}");
        }

        public virtual bool IsPointInside(double x1, double x2)
        {
            return x1 >= _b1 && x1 <= _a1 && x2 >= _b2 && x2 <= _a2;
        }
    }

    public class Parallelepiped : Rectangle
    {
        private double _b3;
        private double _a3;

        public Parallelepiped() : base() { }

        public Parallelepiped(double b1, double a1, double b2, double a2, double b3, double a3)
            : base(b1, a1, b2, a2)
        {
            SetCoefficients(b1, a1, b2, a2, b3, a3);
        }

        public void SetCoefficients(double b1, double a1, double b2, double a2, double b3, double a3)
        {
            base.SetCoefficients(b1, a1, b2, a2);
            _b3 = Math.Min(b3, a3);
            _a3 = Math.Max(b3, a3);
        }

        public override void DisplayCoefficients()
        {
            base.DisplayCoefficients();
            Console.WriteLine($"Dimension 3: {_b3} <= x3 <= {_a3}");
        }

        public bool IsPointInside(double x1, double x2, double x3)
        {
            return base.IsPointInside(x1, x2) && x3 >= _b3 && x3 <= _a3;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(2, 8, 1, 6);
            rectangle.DisplayCoefficients();
            Console.WriteLine("Enter point (x1 x2):");
            string[] rectPoints = Console.ReadLine().Split(' ');
            if (rectPoints.Length == 2)
            {
                Console.WriteLine($"Result: {rectangle.IsPointInside(double.Parse(rectPoints[0]), double.Parse(rectPoints[1]))}");
            }

            Console.WriteLine();

            Parallelepiped parallelepiped = new Parallelepiped(0, 5, 0, 5, 0, 5);
            parallelepiped.DisplayCoefficients();
            Console.WriteLine("Enter point (x1 x2 x3):");
            string[] multiPoints = Console.ReadLine().Split(' ');
            if (multiPoints.Length == 3)
            {
                Console.WriteLine($"Result: {parallelepiped.IsPointInside(double.Parse(multiPoints[0]), double.Parse(multiPoints[1]), double.Parse(multiPoints[2]))}");
            }
        }
    }
}