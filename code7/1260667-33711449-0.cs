    public class Program
        {
            static void Main(string[] args)
            {
                var airport = new Airport { AirportName = "JFK" };
    
                Console.WriteLine(airport.ToString());
            }
        }
    
        public class Airport
        {
            private string _airportName;
    
            public string AirportName
            {
                get
                {
                    return _airportName;
                }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("You did not enter a name for the airport.  Please reenter the information.");
                    }
    
                    _airportName = value;
                }
            }
    
            public override string ToString()
            {
                return string.Format("The airport name is: {0}\r\n", _airportName);
            }
        }
