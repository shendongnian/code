        abstract class Animal : IComparable<Animal>
        {
            public abstract int SortKey { get; }
            public abstract int CompareTo(Animal other);
        }
        class Wolf : Animal
        {
            public int kills = 0; //Marked public for simple initialization
            public override int SortKey { get { return 100; } }
            public override int CompareTo(Animal other)
            {
                if (other.SortKey != SortKey)
                {
                    return SortKey.CompareTo(other.SortKey);
                }
                var otherWolf = other as Wolf;
                if (otherWolf == null)
                {
                    return -1;
                }
                return kills.compareTo(otherWolf.kills);
            }
        }
