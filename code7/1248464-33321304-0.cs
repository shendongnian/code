        public static void Main() 
        { 
           Timer t = new Timer(UpdateThermostat, 5, 0, 10000); //10 times 1000 miliseconds
           t.Dispose(); // dispose the timer
        }
    
    
        private static void UpdateThermostat(Object state) 
        { 
           // your code to get your thermostat
        }
