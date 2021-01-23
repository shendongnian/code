    public struct TimerDescriptor
    {
        public string Name;
        public string Time;
        public string Path;
    
        public static bool TryParse(string text, out TimerDescriptor value)
        {
            //check for empty text
            if (string.IsNullOrWhiteSpace(text))
            {
                value = default(TimerDescriptor);
                return false;
            }
    
            //check for wrong number of arguments
            var split = text.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 3)
            {
                value = default(TimerDescriptor);
                return false;
            }
    
            value = new TimerDescriptor
            {
                Name = split[0],
                Time = split[1],
                Path = split[2]
            };
    
            return true;
        }
    
        public override string ToString()
        {
            return Name + ' ' + Time + ' ' + Path;
        }
    }
    
    static void writeAndWait(String statement, int millisecondsToWait)
    {
        Console.WriteLine(statement);
        Thread.Sleep(millisecondsToWait);
    }
    static void Main(string[] args)
    {
        //I am using ArrayLists because they will store as many values as needed wether it be 1 or 1,000,000 or more
        var timerDescriptors = new List<TimerDescriptor>();
    
        writeAndWait("Hello, if you want to add timers all you need to do is type a name and press enter, say how long you want the timer to run for in minutes, and then add a number 1-10 any timers with the same number at the end will run sycrnasly, and any timers with diferant nubers will run async", 2000);
    
        var line = Console.ReadLine();
        TimerDescriptor descriptor;
        if (TimerDescriptor.TryParse(line, out descriptor))
        {
            timerDescriptors.Add(descriptor);
            Console.WriteLine(descriptor);
        }
        else Console.WriteLine("Syntax error: wrong number of arguments.  The syntax is: {Name} {Time} {Path} without the curly braces.");
    }
