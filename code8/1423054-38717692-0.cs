    namespace StringToIntConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string orders = "Total orders are 2222 open orders are 1233 closed are 222";
                string[] arr = orders.Split(' ');
                List<int> integerList = new List<int>();
                foreach(string aString in arr.AsEnumerable())
                {
                    int correctedValue ;
                    if(int.TryParse(aString,out correctedValue))
                    {
                        integerList.Add(correctedValue);
                    }
                }
                foreach (int aValue in integerList)
                {
                    Console.WriteLine(aValue);
                }
                Console.Read();
            }
        }
    }
