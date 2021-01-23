    public static class SomeExtension
    {
        public static IEnumerable<T> ReplaceDefaultByPreviousNonDefault(this IEnumerable<T> sequence)
        {
            T previous = default(T);
    
            foreach(var val in squence)
            {
                if(val == default(t)) yield return previous;
            
                previous = val;
    
                yield return val;        
            }
        }
    }
