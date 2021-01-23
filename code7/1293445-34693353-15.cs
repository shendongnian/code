    // This class will hold data input results
    public sealed class DataInputResult 
    {
    	public DataInputResult(string data, bool isSuccessful = true, string failReason = null)
    	{
    		Data = data;
    		IsSuccessful = isSuccessful;
    		FailReason = failReason;
    	}
    	public string Data { get; private set; }
    	public bool IsSuccessful { get; private set; }
    	public bool FailReason { get; private set; }
    }
    
    public class DataInput
    {
    	public static Task<DataInputResult> Prompt(string initialMessage, string retryMessage, string regex, int maxTries = 3)
    	{
    		TaskCompletionSource<DataInputResult> resultCompletionSource = new TaskCompletionSource<DataInputResult>();
    		
    		int currentTries = 0;
    		string itemName = null;
    		bool matches = false;
    		
    		while(currentTries < maxTries && !matches)
    		{
    			// If it's not the first try you assume that itemName won't be empty
    			// so it will show the message to prompt the user for a valid item name
    			if (string.IsNullOrEmpty(itemName))
    				Console.WriteLine(initialMessage);
    			else
    				Console.WriteLine(retryMessage, currentTries + 1);
    			
    			itemName = Console.ReadLine();
    			
    			matches = Regex.IsMatch(itemName, regex, RegexOptions.IgnoreCase);
    			
    			if(!matches) currentTries++;
    		}
    		
    		if(matches)
    			resultCompletionSource.SetResult(new DataInputResult(itemName));
    		else
    			resultCompletionSource.SetResult(new DataInputResult(null, false, "Maximum number of tries reached"));
    			
    		
    		return resultCompletionSource.Task;
    	}
    }
