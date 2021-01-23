    namespace ConsoleApp1
    {
        static public class Program
        {
            static IEnumerable<int> FindEven(this IEnumerable<int> array, Func<int, bool> predicte)
            {
                foreach (var n in array)
                {
                    if (predicte(n))
                    {
                        yield return n;
                    }
                }
            }
            static public void Main(string[] args)
            {
                int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
                var result = numbers.FindEven(n => n % 2 == 0);
                foreach (var output in result)
                    Console.WriteLine(output);
    
                Console.ReadLine();
            }
        }
    }
