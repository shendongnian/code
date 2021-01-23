    public interface IListService<T>
    {
        T[] ReadMultiple();
    }
    public class JobList_Service : IListService<Job>, SoapHttpClientProtocol
    {
            public Job[] ReadMultiple()
            {
                 ...
            }
    }
