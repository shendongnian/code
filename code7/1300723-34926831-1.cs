    public void showResults()
    {
        foreach(Track item in trackElements)
        {
            Console.WriteLine(item.Name + ": " + item.Length);
        }
        Console.WriteLine("Number of sections: " + trackElements.Count());
        Console.ReadKey();
    }
