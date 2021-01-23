    /* A class that behaves a lot like an int */
    public class Dzeta
    {
        private int __dzeta;
        public Dzeta() { }
        public Dzeta(int i)
        {
            this.__dzeta = i;
        }
        public static Dzeta operator +(Dzeta a, Dzeta b)
        {
            var c = new Dzeta(a.__dzeta + b.__dzeta);
            return c;
        }
        public static Dzeta operator -(Dzeta a, Dzeta b)
        {
            var c = new Dzeta(a.__dzeta - b.__dzeta);
            return c;
        }
        public static Dzeta operator +(Dzeta a, int b)
        {
            var c = new Dzeta(a.__dzeta + b);
            return c;
        }
        public static Dzeta operator -(Dzeta a, int b)
        {
            var c = new Dzeta(a.__dzeta - b);
            return c;
        }
        public override string ToString()
        {
            return __dzeta.ToString();
        }
        
    }
    /* Extend the int like behaviors of my DZeta class*/
    public static class DZExtensions
    {
        public static Dzeta Sum(this Dzeta self, params Dzeta[] all)
        {
            var z = new Dzeta();
            foreach (var dz in all)
                z += dz;
            return z;
        }
        public static Dzeta Sum(this Dzeta self, params int[] all)
        {
            var z = new Dzeta();
            foreach (var dz in all)
                z += dz;
            return z;
        }
    }
    /* This is how it can be used in the application*/
    public class UsageOfDZeta
    {
        public void DoSomeDZetaWork()
        {
            var zz = new Dzeta(5);
            System.Diagnostics.Debug.WriteLine(zz);     // prints 5
            zz += 15;
            System.Diagnostics.Debug.WriteLine(zz);     // prints 20
            zz.Sum(10, 5, 20, 5);
            System.Diagnostics.Debug.WriteLine(zz);     // prints 60
        }
    }
