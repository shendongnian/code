    static void PrintSlowly(string print)
    {
        foreach(char l in print) {
            Console.Write(l);
            Thread.sleep(10); // sleep for 10 milliseconds    
        }
        Console.Write("\n");
    }
