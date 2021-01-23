    static void Main(string[] args)
    {
        List<string> selectedGreetings = new List<string>();
        /* This will get 1000 greetings, 
         * which are the Content property of the models, group them by the greeting,
         * count them, and then print the count along with the greeting to the Console.
         */
        GetGreetings()
            .Take(1000)
            .GroupBy(x => x)
            .Select(x => new { Count = x.Count(), Content = x.Key })
            .ToList()
            .ForEach(x => Console.WriteLine("{0} : {1}", x.Content, x.Count));
        Console.ReadLine();
    }
