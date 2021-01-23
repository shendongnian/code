    public class Program
    {
    	public static void Main(string[] args)
    	{
    		Test job = new Test(0); 
    		Console.WriteLine(job.Nums.Count);
    		
    		JObject jJob = JObject.FromObject(job);
    		
    		job = jJob.ToObject<Test>();
    		Console.WriteLine(job.Nums.Count); // This is 1 again.
    	}
    }
