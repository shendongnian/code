    public class ServiceWrapper : IServiceWrapper 
    {
        EndpointAddress address;
        public ServiceWrapper(EndpointAddress clientAddress)
        {
             address = clientAddress;
        }
        public async Task<string> DoSomethingAsync(string someParameter)
        {
            // handle exceptions etc here, can be done some cleaner..
            var client = new YourServiceClient();
            client.Endpoint.Address = address.Address; // can skip this..
            await client.OpenAsync()
            var res =  await Task<string>.Factory.FromAsync(client.BeginDoSomeStuff, client.EndDoSomeStuff, someParameter, new object());
            await client.CloseAsync();
            return res;
        }
    }
