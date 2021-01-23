    public class RequestPayload
    {
        public IModelBase Payload { get; set; }
        public TaskCompletionSource<IResultBase> CompletionSource { get; private set; }
    }
    public class HttpConnector 
    {
        private BufferBlock<RequestPayload> queue;
        public Task ProduceRequest(RequestPayload payload)
        {
            if(this.queue == null)
            {
                this.queue = new BufferBlock<RequestPayload>();
                this.ConsumeRequestsAsync(queue);  
            }
            await queue.SendAsync(payload);
            return await payload.CompletionSource.Task;
    }
        public Task ConsumeRequestsAsync(BufferBlock<RequestPayload> queue)
        {
            while(await queue.OutputAvailableAsync())
            {
                try
                {
                     var payload = await queue.ReceiveAsync();
                     //do the HTTP request...
                     payload.CompletionSource.TrySetResult(null);
                }
                catch (Exception e)
                {
                     payload.CompletionSource.TrySetException(e)
                }
           }
       }
    }
    public class Client 
    {
        private HttpConnector connector = new HttpConnector();
        public Task UpdateDataAsync()
        {
            try
            {
                 await connector.ProduceRequest(new RequestPayload());
            } 
            catch(Exception e) { /*handle exception*/ }
        }
    }
