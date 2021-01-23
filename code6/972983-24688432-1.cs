    static void Main(string[] args)
    {
         List<int> test = new List<int> { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 };
         GetData(test, 6);
         foreach (var item in Set)
         {
             Console.WriteLine("\t" + item.Key);
             foreach (var subitem in item.Value)
             {
                 Console.WriteLine(subitem);
             }
         }
    }
