    class Program
    {
        static void Main(string[] args)
        {
    		var measurements = new List<Measurement>();
    		var heat = new string[] 
                { "Mild", "Medium", "Hot", "Super Hot", "Scorching" }.ToList(); 
            
            int counter;
            {
                for (counter = 0; counter != heat.Count; counter++)
    			{
    				var measurement = new Measurement() { Heat = heat[counter]};
                    Console.WriteLine("What do you wish to charge for " +
                        measurement.Heat + " ?");
                    measurement.Price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("How many jars of " + measurement.Heat + 
                        " did you sell last year?");
                    measurement.NumSold = Convert.ToInt32(Console.ReadLine());
    				measurements.Add(measurement);
                }
            }
    
    		measurements.ForEach(x =>
    		{
    			Console.WriteLine("You sold " + x.NumSold + " of "
    				+ x.Heat + " at $" + x.Price + " each.");
    		});
        }
    }
    
    public class Measurement
    {
    	public string Heat { get; set; }
    	public double Price { get; set; }
    	public int NumSold { get; set; }
    }
