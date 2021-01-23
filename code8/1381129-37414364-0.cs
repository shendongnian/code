    namespace Geometry
    {
        public interface IMeasurableSolid
        {
            double CalcSurface();
            double CalcVolume();
        }
        public class Sphere : IMeasurableSolid
        {
            public double Radius { get; set; }
            public Sphere(double radius)
            {
                if (radius <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius", "value must be positive");
                }
                this.Radius = radius;
            }
            public double CalcSurface()
            {
                return (Math.PI * 4 * Math.Pow(this.Radius, 2));
            }
            public double CalcVolume()
            {
                return (Math.PI * 4 * Math.Pow(this.Radius, 3) / 3);
            }
        }
        public class Cylinder : IMeasurableSolid
        {
            public double Height { get; set; }
            public double Radius { get; set; }
            public Cylinder(double height, double radius)
            {
                if (height <= 0)
                {
                    throw new ArgumentOutOfRangeException("height", "value must be positive");
                }
                if (radius <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius", "value must be positive");
                }
                this.Height = height;
                this.Radius = radius;
            }
            public double CalcSurface()
            {
                return 2 * Math.PI * this.Radius * (this.Radius + this.Height);
            }
            public double CalcVolume()
            {
                return this.Height * Math.PI * Math.Pow(this.Radius, 2);
            }
        }
    }
