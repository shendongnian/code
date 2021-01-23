    public class Point<T>
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        
        protected readonly Type[] AllowedTypes = 
            {
                typeof(decimal), typeof(double), typeof(short), typeof(int), typeof(long),
                typeof(sbyte), typeof(float), typeof(ushort), typeof(uint), typeof(ulong)
            };
        public Point()
        {   
            if (!this.AllowedTypes.Contains(typeof(T)))
            {
                throw new NotSupportedException(typeof(T).ToString());
            }           
        }
        public T X { get; set; }
        public T Y { get; set; }
        // UPDATE: arithmetic operations require dynamic proxy-Properties or
        // variables since T is not explicitly numeric... :(
        public T CalculateXMinusY()
        {
            dynamic x = this.X;
            dynamic y = this.Y;
            return x - y;
        }
    }
