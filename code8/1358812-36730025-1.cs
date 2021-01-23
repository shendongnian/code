    class Program
    {
        static void Main(string[] args)
        {
    		var measurements = new Measurements();
    		measurements.Heat = new string[] { "Mild", "Medium", "Hot", "Super Hot", "Scorching" }.ToList(); 
            measurements.Price = new List<double>(4);
            measurements.NumSold = new List<int>(4);
    
            int counter;
            {
                for (counter = 0; counter != measurements.Heat.Count; counter++)
                {
                    Console.WriteLine("What do you wish to charge for " + measurements.Heat[counter] + " ?");
                    measurements.Price[counter] = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("How many jars of " + measurements.Heat[counter] + " did you sell last year?");
                    measurements.NumSold[counter] = Convert.ToInt32(Console.ReadLine());
                }//end forloop
    
            } 
    
            for (int count = 0; count < measurements.Heat.Count; count++)
            {
                Console.WriteLine("You sold " + measurements.NumSold[count] + " of " 
    				+ measurements.Heat[count] + " at $" + measurements.Price[count] + " each.");
            }//end forloop
    		
    		// your arraySalsa is now just your measurements instance
        }
    }
    
    public class Measurements
    {
    	public List<string> Heat { get; set; }
    	public List<double> Price { get; set; }
    	public List<int> NumSold { get; set; }
    }
