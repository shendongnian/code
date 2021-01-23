        public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> source, T value)
        {
            using (var e = source.GetEnumerator())
            {
                if (e.MoveNext())
                {
                    var list = new List<T> { };
                    //In case the source doesn't start with 0
                    if (!e.Current.Equals(value))
                    {
                        list.Add(e.Current);
                    }
                    while (e.MoveNext())
                    {
                        if ( !e.Current.Equals(value))
                        {
                            list.Add(e.Current);
                        }
                        else
                        {
                            yield return list;
                            list = new List<T> { };
                        }
                       
                    }
                    //In case the source doesn't end with 0
                    if (list.Count>0)
                    {
                        yield return list;
                    }
                 
                }
            }
        }
  
