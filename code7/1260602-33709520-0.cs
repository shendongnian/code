    public static class CommonPartExtension
    {
        public static IEnumerable<T> CommonPart<T>(this IEnumerable<T> source1, 
                                                        IEnumerable<T> source2)
        {
            IEnumerator<T> enumerator1 = source1.GetEnumerator();
            IEnumerator<T> enumerator2 = source2.GetEnumerator();
            while( enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                if ( enumerator1.Current.Equals(enumerator2.Current) )
                    yield return enumerator2.Current;
                else
                    yield break ;
            }
        }
    }
