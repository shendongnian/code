     class OnlyPositiveInt : IEqualityComparer<int>
        {
            public bool Equals(int first, int second)
            {
                if ( first > 0 && second > 0)   { return true; }
                return false;
            }
            public int GetHashCode(int x)
            {
                return x.GetHashCode();
            }
        }
     List<int> onlyPositive = new List<int>(generatedList.Distinct(OnlyPositiveInt));
