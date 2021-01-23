    public class Logger
    {
    	private ActionBlock<string> block;
    	public Logger(string filePath)
    	{
    		block = new ActionBlock<string>(async message => {
    			using(var f = File.OpenWrite(filePath))
    			using(var sw = new StreamWriter(f))
    			{
    				await sw.WriteLineAsync(message);
    			}
    		}, new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = 1});
    
    	}
    	public void Log(string message)
    	{
    		block.Post(message);
    	}
    }
