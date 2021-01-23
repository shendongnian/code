    public class DataResult
    {
        internal DataResult(IEnumerable<DataRecord> records)
        {
            Records = records;
        }
        
        public IEnumerable<DataRecord> Records { get; private set; }
        public Exception Exception { get; internal set; }
    }
    public static DataResult GetData(String serverAddress, Int64 dataID)
    {
        BlockingCollection<DataRecord> records = new BlockingCollection<DataRecord>();
        DataResult result = new DataResult(records.GetConsumingEnumerable());
        Task.Run(
            () =>
            {
                try
                {
                    Boolean isMoreData = false;
                    do
                    {
                        // make server request and process response
                        // this block can throw
                        records.Add(response.record);
                        isMoreData = response.IsMoreData;
                    }
                    while (isMoreData);
                }
                catch (Exception ex)
                {
                    result.Exception = ex;
                }
                finally
                {
                    records.CompleteAdding();
                }
            });
        return result;
    }
