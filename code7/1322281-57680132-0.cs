    public static IEnumerable<IEnumerable<T>> Clone<T>(this IEnumerable<IEnumerable<T>> twoDList) where T : ICloneable
            {
                if (twoDList != null)
                {
                    List<List<T>> result = new List<List<T>>();
                    for (int i = 0; i < twoDList.Count(); i++)
                    {
                        List<T> aList = new List<T>();
                        for (int j = 0; j < twoDList.ElementAt(i).Count(); j++)
                        {
                            aList.Add(twoDList.ElementAt(i).ElementAt(j));
                        }
                        result.Add(aList);
                    }
                    return result;
                }
                else
                {
                    return null;
                }
            }
