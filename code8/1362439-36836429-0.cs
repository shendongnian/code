    public interface ITimeSeriesData
    {
        ITimeSeriesData Add(ITimeSeries timeSeries);
    }
    public interface ISquareTimeSeriesData : ITimeSeriesData
    {
        new ISquareTimeSeriesData Add(ITimeSeries timeSeries); // hide original
    }
    public class STSD : ISquareTimeSeriesData
    {
        public ISquareTimeSeriesData Add(ITimeSeries timeSeries)
        {
            // implement here
        }
        ITimeSeriesData ITimeSeriesData.Add(ITimeSeries timeSeries)
        {
            return this.Add(timeSeries); // call the overridden Add method
        }
    }
