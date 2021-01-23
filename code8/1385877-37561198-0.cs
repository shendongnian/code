    using System.Linq;
    					
    public class Program
    {
    	public  void ABC()
    	{
    
    		
    		var data = "123456789";
    		const int separateOnLength = N;
    
    		var separated = new string(
       		 data.Select((x,i) => i > 0 && i % separateOnLength == 0 ? new [] { ',', x } : new [] { x })
            .SelectMany(x => x)
            .ToArray()
        );
    		
    	}
    }
