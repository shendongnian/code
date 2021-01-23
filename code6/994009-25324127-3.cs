    public class ServiceWrapper : IServiceWrapper 
    {
        readonly YourServiceClient client;
        public ServiceWrapper(YourServiceClient client)
        {
            this.client = client;
        }
        public async Task<string> DoSomethingAsync(string someParameter)
        {
            return await Task<string>.Factory.FromAsync(client.BeginDoSomeStuff, client.EndDoSomeStuff, someParameter, new object());
        }
    }
