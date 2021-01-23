    [ServiceContract]
    public interface IRainfallMonitor
    {
        [OperationContract]
        void RecordRainfall(string county, float rainfallInches);
    }
    public class RainfallMonitor : IRainfallMonitor
    {
        public void RecordRainfall(string county, float rainfallInches)
        {
            // code
        }
    }
