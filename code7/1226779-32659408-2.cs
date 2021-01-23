    public class Program
    {    
        public static void Main(string[] args)
        {
        	try
        	{	        
        			throw new ConnectionLostException();
        	}
        	catch (Exception ex)
        	{
        		
        		if (ex is LoginInfoException)
        		{
        			Console.WriteLine ("LoginInfoException");
        		}
        		else if (ex is ConnectionLostException)
        		{
        			Console.WriteLine ("ConnectionLostException");	
        		}
        	}
        }
    }
        
    public class LoginInfoException : WebException
    {
       public String Message { get; set; }
        
    }
        
    public class ConnectionLostException : WebException
    {
       public String Message { get; set; }
    }
