    public static class Extensions
    {
        public static IEnumerable<T[]> Pivot<T>(this IEnumerable<IEnumerable<T>> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return PivotIterator(source);
        }
        
        private static IEnumerable<T[]> PivotIterator<T>(IEnumerable<IEnumerable<T>> source)
        {
            var enumerators = new List<IEnumerator<T>>();
            try
            {
                foreach (IEnumerable<T> item in source)
                {
                    enumerators.Add(item.GetEnumerator());
                }
                
                bool stillGoing = true;
                while (stillGoing)
                {
                    foreach (IEnumerator<T> item in enumerators)
                    {
                        if (!item.MoveNext())
                        {
                            stillGoing = false;
                            break;
                        }
                    }
                    if (stillGoing)
                    {
                        var result = new T[enumerators.Count];
                        for (int index = 0; index < enumerators.Count; index++)
                        {
                            result[index] = enumerators[index].Current;
                        }
                        
                        yield return result;
                    }
                }
            }
            finally
            {
                foreach (IDisposable item in enumerators)
                {
                    item.Dispose();
                }
            }
        }
    }
