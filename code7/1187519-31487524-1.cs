    bool Continue(IEnumerable<BrokeredMessage> prev)
    {
        return prev.Any();
    }
    
    Task<IEnumerable<BrokeredMessage>> ProduceFirst()
    {
    	return
    		Task.FromResult(
    			EnumerableEx.Return(
    				new BrokeredMessage()
    				{
    					SequenceNumber = 1
    				}));
    }
    
    Task<IEnumerable<BrokeredMessage>> ProduceNext(IEnumerable<BrokeredMessage> prev) 
    {
        return Task.FromResult(
    		prev.Last().SequenceNumber < 3
    			? EnumerableEx.Return(
    				new BrokeredMessage()
    				{
    					SequenceNumber = prev.Last().SequenceNumber + 1 
    				})
    			: Enumerable.Empty<BrokeredMessage>());
    }
    
    public class BrokeredMessage
    {
    	public int SequenceNumber;
    }
