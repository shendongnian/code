    public class Vector 
    {
        public Vector(Unit unit, int size)
        {
            this.Elements=new double[size];
            this.Unit=unit;
        }
        public Vector(Unit unit, params double[] values)
        {
            this.Unit=unit;
            this.Elements=values;
        }
        public Unit Unit { get; private set; }
        public double[] Elements { get; private set; }
        public double this[int index] { get { return Elements[index]; } }
        public int Count { get { return Elements.Length; } }
        public Vector ConvertTo(Unit target)
        {
            double factor=Unit.FactorTo(target);
            double[] values=Array.ConvertAll(Elements, (x) => factor*x);
            return new Vector(target, values);
        }
        public override string ToString()
        {
            string[] items=Array.ConvertAll(Elements, (x) => x.ToString());
            return string.Format("[{0}] in {1}", string.Join(",", items), Unit.ToString());
        }
        public static Vector operator+(Vector x, Vector y)
        {
            if(x.Count==y.Count)
            {
                x=x.ConvertTo(y.Unit);
                double[] result=new double[x.Count];
                for(int i=0; i<result.Length; i++)
                {
                    result[i]=x[i]+y[i];
                }
                return new Vector(y.Unit, result);
            }
            throw new IndexOutOfRangeException("Vectors must have the same number of elements.");
        }
        public static Vector operator-(Vector x, Vector y)
        {
            if(x.Count==y.Count)
            {
                x=x.ConvertTo(y.Unit);
                double[] result=new double[x.Count];
                for(int i=0; i<result.Length; i++)
                {
                    result[i]=x[i]-y[i];
                }
                return new Vector(y.Unit, result);
            }
            throw new IndexOutOfRangeException("Vectors must have the same number of elements.");
        }
        public static Vector operator*(double x, Vector y)
        {
            double[] result=new double[y.Count];
            for(int i=0; i<result.Length; i++)
            {
                result[i]=x*y[i];
            }
            return new Vector(y.Unit, result);
        }
        public static Vector operator*(Vector x, Vector y)
        {
            if(x.Count==y.Count)
            {
                double[] result=new double[x.Count];
                for(int i=0; i<result.Length; i++)
                {
                    result[i]=x[i]*y[i];
                }
                return new Vector(x.Unit* y.Unit, result);
            }
            throw new IndexOutOfRangeException("Vectors must have the same number of elements.");
        }
        public static Vector operator/(Vector x, Vector y)
        {
            if(x.Count==y.Count)
            {
                double[] result=new double[x.Count];
                for(int i=0; i<result.Length; i++)
                {
                    result[i]=x[i]/y[i];
                }
                return new Vector(x.Unit/y.Unit, result);
            }
            throw new IndexOutOfRangeException("Vectors must have the same number of elements.");
        }
    }
