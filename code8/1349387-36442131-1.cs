    namespace ConsoleApp1
    {
        static public class Program
        {
            static public void Main(string[] args)
            {
                int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
                var result = numbers.Where(n => n % 2 == 0);
                foreach (var output in result)
                    Console.WriteLine(output);
    
                Console.ReadLine();
            }
        }
    }
