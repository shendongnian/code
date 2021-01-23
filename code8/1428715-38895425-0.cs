    static void Main(string[] args)
    {
        try
        {
            var task = Task.Run(async () => { return await AsyncMethod(); });
            Console.WriteLine("Result: " + task.Result);
        }
        catch
        {
            Console.WriteLine("Exception caught!");
        }
    
        Console.ReadKey();
    }
    
    static async Task<string> AsyncMethod()
    {
        throw new ArgumentException();
    
        var result = await Task.Run(() => { return "Result from AsyncMethod"; });
        return result;
    }
