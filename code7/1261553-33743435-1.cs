    namespace System.Collections.Generic
    {
        public static class Enumerable
        {
            //[System.Runtime.CompilerServices.Extension()]
            public static bool All<T>(this IEnumerable<T> list, T expectedAnswer)
                where T : IEquatable<T>, IComparable<T>
            {
                bool result = true;
                T next;
    
                IEnumerator<T> enumerator = list.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    next = enumerator.Current;
                    result = result && (Object.Equals(next, expectedAnswer));
    
                    if (!result)
                        return result;
                }
                return result;
            }
    
            public delegate bool MyFunc<T>(T next);
    
    
            public static bool All<T>(this IEnumerable<T> list, MyFunc<T> fn)
                where T : IEquatable<T>, IComparable<T>
            {
                bool result = true;
                T next;
    
                IEnumerator<T> enumerator = list.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    next = enumerator.Current;
                    result = result && fn.Invoke(next);
    
                    if (!result)
                        return result;
                }
                return result;
            }
        }
    }
