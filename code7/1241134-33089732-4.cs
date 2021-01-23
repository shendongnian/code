    public static class Utils {
    
        public static T MinBy<T,R> (this IEnumerable<T> source, Func<T,R> f) where R : IComparable<R> {
            IEnumerator<T> e = source.GetEnumerator();
            if(!e.MoveNext()) {
                throw new Exception("You need to provide at least one element.");
            }
            T min = e.Current;
            R minf = f(min);
            while(e.MoveNext()) {
                T x = e.Current;
                R xf = f(x);
                if(minf.CompareTo(xf) > 0) {
                    min = x;
                    minf = xf;
                }
            }
            return min;
        }
    
    }
