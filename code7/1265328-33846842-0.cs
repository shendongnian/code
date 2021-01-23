    public class Query {...}
    public interface IClient
    {
        [Get("/api/endpoint")]
        Task<Result> GetData(Query data);
    }
