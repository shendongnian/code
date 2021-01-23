    public class Split
    {
    	public static List<string> Extract(string source, string splitStart, string splitEnd)
    	{
    		try
    		{
    			var results = new List<string>();
    
    			string[] start = new string[] { splitStart };
    			string[] end = new string[] { splitEnd };
    			string[] temp = source.Split(start, StringSplitOptions.None);
    
    			for (int i = 1; i < temp.Length; i++)
    			{
    				results.Add(temp[i].Split(end, StringSplitOptions.None)[0]);
    			}
    
    			return results;
    		}
    		catch (Exception e)
    		{
    			throw new Exception(e.Message);
    		}
    	}
    }
