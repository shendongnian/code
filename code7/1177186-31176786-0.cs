    public interface IComparePatternAndData
    {
        int PatternId { get; }
        // of course the actual compare method(s) go here as well...
    }
    public interface IPatternDictionary
    {
        bool TryGetValue(int key, out IComparePatternAndData value);
    }
    public class PatternDictionary : Dictionary<int, IComparePatternAndData>, IPatternDictionary
    {
        public PatternDictionary(IComparePatternAndData[] patterns)
        {
            foreach (IComparePatternAndData pattern in patterns)
            {
                this[pattern.PatternId] = pattern;
            }
        }
    }
