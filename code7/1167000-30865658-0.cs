    static async Task<string> DoStuff()
    {
        Console.WriteLine("Long running op started");
        var myString = await Task.Run(() =>
        {
            var result = "Test";
            for (int counter = 0; counter < 5000; counter++)
            {
                Console.WriteLine(counter);
            }
            return (result);
        });
        Console.WriteLine(myString);
        return myString;
    }
    
    static void Main(params string[] args)
    {
        var task = DoStuff();
    
        while (!task.IsCompleted)
        {
            Console.WriteLine("Doing Stuff on the Main Thread...................");
        }
    }
