    public interface ISampleViewModelReader
    {
        int Value1    { get; }
        string Value2 { get; }
        double Value3 { get; }
        string Value4 { get; }
    }
    public class AggregatedSampleViewModelReader : ISampleViewModelReader
    {
        public AggregatedSampleViewModelReader(IReader1 reader1, IReader2 reader2, IReader3 reader3)
        {
            // ...
        }
        // ...
        double Value3 { get { return reader2.Value3; } }
        // ...
    }
    public class SampleViewModel
    {
        public SampleViewModel(ISampleViewModelReader reader)
        {
            // ...
        }
    }
