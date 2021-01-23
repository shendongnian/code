    public class IntSampleDataProvider : ISampleDataProvider<int>
    {
        public IEnumerable<int> CreateSampleValues()
        {
            yield return 3;
            yield return 0;
            yield return int.MaxValue;
            yield return int.MinValue;
        }
    }
