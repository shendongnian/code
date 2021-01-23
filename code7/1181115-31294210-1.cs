    class Program
        {
            static void Main(string[] args)
            {
                List<string> list = new List<string>();
                list.Add("First");
                list.Add("second");
                list.Add("third");
    
                Dictionary<int, string> dictionary = new Dictionary<int, string>();
    
                dictionary.Add( 1,"First");
                dictionary.Add(2,"second");
    
                foreach (var li in list)
                {
    
                    if (!dictionary.ContainsValue(li))
                    {                  
                        Console.WriteLine(li);
                    }
                }
                Console.ReadLine();
            }
        }
