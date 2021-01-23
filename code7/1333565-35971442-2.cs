    class Comparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int> x, List<int> y)
            {
                return Enumerable.SequenceEqual(x.OrderBy(t => t), y.OrderBy(t => t));
            }
            public int GetHashCode(List<int> obj)
            {
                var list = objs.OrderBy(t => t);
                unchecked
                {
                    int hash = 19;
                    foreach (var obj in list)
                    {
                        hash = hash * 31 + obj.GetHashCode();
                    }
                    return hash;
                }
            }
        }
         ....
        group.GroupBy(x => x.PossibleValues, new Comparer());
