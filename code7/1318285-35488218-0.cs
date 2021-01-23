    public class Tile
    {
        public readonly int producerId;
        public readonly int level;
        public class Id : Tuple<int, Tuple<int, int>>
        {
            public Id(int value1, int subvalue1, int subvalue2)
                : base(value1, new Tuple<int, int>(subvalue1, subvalue2))
            {
            }
        }
        public class TId : Tuple<int, Tuple<int, int>>
        {
            public TId(int value1, int subvalue1, int subvalue2)
                : base(value1, new Tuple<int, int>(subvalue1, subvalue2))
            {
            }
        }
    }
