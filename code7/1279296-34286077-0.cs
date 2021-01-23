    static void Main(string[] args)
    {
         string value1 = "First";
         Console.WriteLine(value1);
    
         GetSecondFromAsync();
    
         string value3 = "Third";
         Console.WriteLine(value3);
    
         string value4 = "Fourth";
         Console.WriteLine(value4);
    
         Console.ReadKey();
    }
    private static async void GetSecondFromAsync()
    {
       await Task.Delay(3000);
       Console.WriteLine("Second");
    }
