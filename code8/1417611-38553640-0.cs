    class Program
    {
        static void Main(string[] args)
        {
           string result = "4";
           for(int start = 5; start <= 13; start++)
           {
              result += " then" + start;
           }
           Console.Write(result);
           Console.ReadKey();
        }
    }
