    public class InterlockedInt
    {
        private int cnt;
        public int Cnt
        {
            get
            {
                return cnt;
            }
        }
        public void Increment()
        {
            Interlocked.Increment(ref cnt);
        }
    }
    public static IDictionary<string, InterlockedInt> Parse(string path)
    {
        var wordCount = new ConcurrentDictionary<string, InterlockedInt>();
        Action<string> action = line2 =>
        {
            var words = line2.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                wordCount.GetOrAdd(word, x => new InterlockedInt()).Increment();
            }
        };
        IEnumerable<string> lines = File.ReadLines(path);
        Parallel.ForEach(lines, action);
        return wordCount;
    }
