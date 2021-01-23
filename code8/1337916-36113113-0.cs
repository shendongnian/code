    public struct Stat
    {
        public int StatValue { get; set; }
        public int StatLast { get; set; }
        public Stat(int statValue, int statLast) : this()
        {
                StatValue = statValue;
                StatLast = statLast;
        }
    }
