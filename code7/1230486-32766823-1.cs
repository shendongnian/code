    public class Program
    {
        public static void Main(string[] args)
        {
            // note updated to use a list rather than array (just preference)
            List<int> data = GetData();         
        }
    
        private static List<int> GetData()
        {
            List<int> list = new List<int>();
            int intValue = 0;
    		int invalidAttempts = 0;
    
            while (true)
            {
                Console.WriteLine("Enter a number 0-10 (Q to end)");
                string lineValue = Console.ReadLine();
    
                if (lineValue.ToLower().Trim().Equals("q"))
                {
                    break;
                }
    
                if (!int.TryParse(lineValue, out intValue))
                {
                    Console.WriteLine("INVALID DATA - Try again.");
    				invalidAttempts++;
                    continue;
                }
    
                if (intValue < 0 || intValue > 10)
                {
                    Console.WriteLine("NUMERIC DATA OUT OF RANGE - Try again.");
    				invalidAttempts++;
                    continue;
                }
    
                list.Add(intValue);
            }
    		
    		Console.WriteLine("Invalid attempts {0}", invalidAttempts);
    		
            // this is using linq to group by the individual numbers (keys),
            // then creates an anon object for each key value and the number of times it occurs.
            // Create new anon object numbersAndCounts
    		var numbersAndCounts = list
                // groups by the individual numbers in the list
    			.GroupBy(gb => gb)
                // selects into a new anon object consisting of a "Number" and "Count" property
    			.Select(s => new {
    				Number = s.Key,
    				Count = s.Count()
    			});
    			
    		foreach (var item in numbersAndCounts)
    		{
    			Console.WriteLine("{0} occurred {1} times", item.Number, item.Count);
    		}
    		
            return list;
        }
    }
