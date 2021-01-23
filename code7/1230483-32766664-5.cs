    static void Main(string[] args)
    {
        int[] data = GetData();
    
        var statistics = data.GroupBy(x=>x)
                             .Select(gr => new 
                             { 
                                 Number = gr.key, 
                                 Times = gr.Count() 
                             });
        foreach(var statistic in statistics)
        {
            Console.WriteLine(String.Format("The number {0} found {1} times in you array", statistic.Number, statistic.Times));
        }
    }
