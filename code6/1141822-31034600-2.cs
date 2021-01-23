    public class ClientServiceInterface : IClientServiceInterface
    {
    private readonly CallbackHandler<string> getNodeNameHandler = new
    CallbackHandler<string>();
    public Task<string> GetNodeNameAsync(int timeout = 1000)
        {
            CallbackHandle<string> callbackHandle = this.getNodeNameHandler.AddCallback(timeout);
            var serviceMessage = new ServiceMessage
                                     {
                                         Type = MessageType.GetNodeName.ToString()
                                     };
            this.ReadyMessage(serviceMessage);
            return callbackHandle.TaskCompletionSource.Task;
        }
    // Rest of class declaration removed for brevity
    }
