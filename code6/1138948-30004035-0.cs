    abstract class Flower : IComparer<Flower>
    {
        public int Leaves { get; set; }
        public int Compare(Flower x, Flower y)
        {
            if (x.Leaves > y.Leaves)
                return 1;
            if (x.Leaves < y.Leaves)
                return -1;
            else
                return 0;
        }
    }
