        public static void Main() 
        {  
           System.Threading.Timer t = new System.Threading.Timer(UpdateThermostat, 5, 0, 2000); //10 times 1000 miliseconds
           Console.ReadLine();
           t.Dispose(); // dispose the timer
        }
    
    
        private static void UpdateThermostat(Object state) 
        { 
           // your code to get your thermostat
            Console.WriteLine(DateTime.Now);
        }
