    public Action<string> PrintCounter()
    {
        int counter = 0;
        return prefix => 
            Console.WriteLine(prefix + " " + (counter++).ToString());
    }
