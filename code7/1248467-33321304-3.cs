    public static void Main() 
    {  
       System.Threading.Timer t = new System.Threading.Timer(UpdateThermostat, 5, 0, 2000); //10 times 1000 miliseconds
       Console.ReadLine();
       t.Dispose(); // dispose the timer
    }
    private static void UpdateThermostat(Object state) 
    { 
       // your code to get your thermostat
       //option one to print on the same line:
       //move the cursor to the beginning of the line before printing:
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(DateTime.Now);
       //option two to print on the same line:
       //printing "\r" moves cursor back to the beginning of the line so it's a trick:
        Console.Write("\r{0}",DateTime.Now);
    }
