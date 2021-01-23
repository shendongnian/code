    public class DataRoot<T> where T : class
    {
        public DataResponse<T> Values { get; set;}
    }
    public interface IDataResponse<T> where T : class
    {
        List<T> Data { get; set; }
    }
    public class DataResponse<T> : IDataResponse<T> where T : class
    {
        [JsonProperty("value")]
        public List<T> Data { get; set; }
    }
