    public class DataInput
    {
    	public static Task<string> Prompt(string initialMessage, string retryMessage, string regexPattern, int maxTries = 3)
    	{
    		TaskCompletionSource<string> resultCompletionSource = new TaskCompletionSource<string>();
    		
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
    			
    			matches = Regex.IsMatch(itemName, regexPattern, RegexOptions.IgnoreCase);
    			
    			if(!matches) currentTries++;
    		}
    		
    		if(matches)
    			resultCompletionSource.SetResult(itemName);
    		else
    			resultCompletionSource.SetException(new InvalidOperationException("Maximum number of tries reached"));
    		
    		return resultCompletionSource.Task;
    	}
    }
