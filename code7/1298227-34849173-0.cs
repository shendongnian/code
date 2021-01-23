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
    }
