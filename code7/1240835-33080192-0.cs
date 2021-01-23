    public class Program
    {
    	public void Main(string[] args)
    	{
    		Random rand = new Random();
    		bool flag = true;
    		int count = 0;
    		while (flag)
    		{
    			Thread.Sleep(1000);
    			var heart_rate = rand.Next(50,70);
    			Console.WriteLine (heart_rate);
    			if (heart_rate < 60)
    			{
    				count++;
    			}
    			else if(heart_rate > 60)
    			{
    				count=0;
    			}
    			else if(count==10)
    			{
    				Console.WriteLine ("dead");
    				flag = false;
    			}
    		}
    	}
    }
