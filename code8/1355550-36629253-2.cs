       public interface IServiceClient { CustomResponse Test(string test); }
        public class ServiceClient : ClientBase< IService>, IServiceClient
        {
            public CustomResponse Test(string test)
            {
                return Channel.Test(test);
            }
        }</code>
4. Consume client:
       IServiceClient client = new ServiceClient(); //or some DI
        var result = client.Test("Test");</code>
