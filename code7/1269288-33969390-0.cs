       class Program
        {
            static void Main(string[] args)
            {
                string example = "/TEST/TEST123";
    
                var result = GetFirstItem(example);
    
                Console.WriteLine("First in the list : {0}", result);
    
            }
    
            static string GetFirstItem(string value)
            {
                var collection = value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var result = collection[0];
                return result;
            }
        }
