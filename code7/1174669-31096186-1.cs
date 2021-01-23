     class OnlyPositiveInt : IEqualityComparer<int>
        {
            public bool Equals(List<int> some)
            {
                if ( some.First() > 0 && some.Last() > 0)   { return true; }
                return false;
            }
            public int GetHashCode(int x)
            {
                return x.GetHashCode();
            }
        }
     List<List<int>> onlyPositive = new List<List<int>>(generatedList.Distinct(OnlyPositiveInt));
