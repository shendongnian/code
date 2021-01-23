    static void Main()
    {
        using (StringWriter stringWriter = new StringWriter())
        {
             Console.SetOut(stringWriter);
             
             //All console outputs goes here
             Console.WriteLine("You are travelling north at a speed of 10m/s");
    
             string consoleOutput = stringWriter.ToString();
        }
    }
