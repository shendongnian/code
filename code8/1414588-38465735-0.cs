    private async Task<TResult> Execute<TService, TResult>(Func<TService, Task<TResult>> operation)
    {
        var address = new EndpointAddress("http://localhost:34801/A");
        var binding = new BasicHttpBinding();
        var channel = ChannelFactory<TService>.CreateChannel(binding, address);
        var clientChannel = (IClientChannel)channel;
        try
        {
            var result = await operation(channel).ConfigureAwait(false);
            return result;
        }
        finally
        {
            if (clientChannel.State != CommunicationState.Faulted)
            {
                await Task.Factory.FromAsync(clientChannel.BeginClose, clientChannel.EndClose, null).ConfigureAwait(false);
            }
            else if (clientChannel.State != CommunicationState.Closed)
            {
                clientChannel.Abort();
            }
        }
    }
