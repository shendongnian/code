    infos.OrderBy(x => Convert.ToInt32(x.Split('-')[0]))
    class Program11
        {
            static void Main(string [] args)
            {
                var infos = new List<string> { "1-100.jpg", "13-11.jpg", "2-145.jpg", "3-421.jpg", "4-842.jpg", "5-1000.jpg" };
    
                var orderedList = infos.OrderBy(x => Convert.ToInt32(x.Split('-')[0]));
    
                foreach (var lstItem in orderedList)
                {
                    Console.WriteLine(lstItem);
                }
    
                Console.ReadKey();
            }
        }
