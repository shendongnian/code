    IDisposable Consume(IQueue queue, Action<byte[], MessageProperties, MessageReceivedInfo> onMessage)
    {
    	Func<byte[], MessageProperties, MessageReceivedInfo, Task> taskWrapper = (bytes, properties, info) =>
    	{
    		onMessage(bytes, properties, info);
    		return new Task(() => { });
    	};
    	Consume(queue, taskWrapper);
    }
