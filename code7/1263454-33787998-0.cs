    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dictionary = new SortedDictionary<int, string> {{1, "First"}, {2, "Second"}, {10, "10th"}};
                Console.WriteLine(GetNext(1, dictionary));
                Console.WriteLine(GetNext(3, dictionary));
                Console.WriteLine(GetNext(11, dictionary));
    
                Console.ReadLine();
            }
    
            private static string GetNext(int key, SortedDictionary<int, string> dictionary)
            {
                return dictionary.ContainsKey(key)
                    ? dictionary[key]
                    : dictionary.FirstOrDefault(kvp => kvp.Key > key).Value;
            }
        }
    }
