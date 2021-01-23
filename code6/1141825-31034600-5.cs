    public class ClientServiceInterface : IClientServiceInterface
    {
    private readonly CallbackHandler<string> getNodeNameHandler;
    public ClientServiceInterface(IMessageEventHandler messageEventHandler, int responseTimeout = 5000)
        {
            this.messageEventHandler = messageEventHandler;
            this.ResponseTimeout = responseTimeout;
            this.getNodeNameHandler = new
    CallbackHandler<string>();
            this.messageEventHandler.OnNodeNameReceived += args => this.getNodeNameHandler.EventTriggered(args);
        }
    public Task<string> GetNodeNameAsync()
        {
            CallbackHandle<string> callbackHandle = this.getNodeNameHandler.AddCallback(this.ResponseTimeout);
            var serviceMessage = new ServiceMessage
                                     {
                                         Type = MessageType.GetNodeName.ToString()
                                     };
            this.ReadyMessage(serviceMessage);
            return callbackHandle.TaskCompletionSource.Task;
        }
    // Rest of class declaration removed for brevity
    }
