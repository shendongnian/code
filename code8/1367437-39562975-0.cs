    public class DataRoutersFactory : IDataRoutersFactory
    {
          private readonly IConfiguration _config;
          public DataRoutersFactory(IConfiguration config)
          {
               _config = config;
          }
          public IEnumberable<IDataRouters> CreateDataRouters()
          {
              // TODO:- use whatever logic here to read _config and build the data routers to return.
          }
    }
