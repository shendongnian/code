    class Comparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int> x, List<int> y)
            {
                return Enumerable.SequenceEqual(x.OrderBy(t => t), y.OrderBy(t => t));
            }
            public int GetHashCode(List<int> obj)
            {
                throw new NotImplementedException();
            }
        }
         ....
        group.GroupBy(x => x.PossibleValues, new Comparer());
