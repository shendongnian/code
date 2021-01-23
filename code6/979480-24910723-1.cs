    public class SomeBuilder<I, O>
    {
    	private I _data;
    	private Func<I, O> _dataProcessor;
    	public SomeBuilder(I data, Func<I, O> dataProcessor)
    	{
    		_data = data;
    		_dataProcessor = dataProcessor;
    	}
    
    	public void Build()
    	{
    		var processedData = _dataProcessor(_data);
    		//do the fun building stuff with processedData
    	}
    }
    // untested
    // e.g. a stringifier-builder
    var builder = new SomeBuilder(42, data => data.ToString());
