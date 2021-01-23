    class Program {
      private static string result;
    
      static void Main() {
        SaySomething().Wait();
        Console.WriteLine(result);
      }
    
      static async Task<string> SaySomething() {
        await Task.Delay(5);
        result = "Hello world!";
        return “Something”;
      }
    }
