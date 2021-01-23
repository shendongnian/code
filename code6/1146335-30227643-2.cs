    public static class Program
    {
    	public static void Main()
    	{
    		string words = "1sdklfjlsdf2lksjdf3sfd4sfd5fsd6fsd7fsd8fsd9sfd10aslkdfj";
    		int id = 1;
    		string [] split = words.Split(new Char [] {'1', '2','3','4','5','6','7','8','9','0'});
    		int deleteRecordId = id -1;
    		string newString = "";
    		int j = 0;
    		for( int i = 0; i < split.Length; i++)
    		{
    			
       			if ( i == deleteRecordId)
        		{
           		 //ignore this record
    			 Console.WriteLine("ignore i = " + i);
    				j++;
        		}
       			else
        		{
    			 	Console.WriteLine("i = " + i);
    				if(!( split[i] == ""))
    				{
            			newString += j +  split[i];
    					j++;
    				}
        		}
    			
    		}
    		Console.WriteLine(newString);
    	}
    	
    	
    }
