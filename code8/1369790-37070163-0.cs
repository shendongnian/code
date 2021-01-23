        public class bar : IComparable
        {
            public string name { get; set; }
            public int CompareTo(object other)
            {
                return this.name.CompareTo(((bar)other).name);
            }
        }
