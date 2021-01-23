        public static MajorantResult FindMajorant(IList<int> numbers)
        {
            return numbers
                .GroupBy(x => x)
                .Where(g => g.Count() >= numbers.Count/2 + 1)
                .Select(g => new MajorantResult(g.Key))
                .SingleOrDefault();
        }
        public class MajorantResult
        {
            public int Key { get; }
            public MajorantResult(int key)
            {
                this.Key = key;
            }
        }
