     static void Main(string[] args)
            {
                int[] arr = new int[] { 1, 2, 1, 4, 5, 1, 2, 2, 2 };
                int occurrenceLimit = 2;
                var newList = new List<int>();
    
                foreach (var item in arr.GroupBy(x => x))
                {
                    newList.AddRange(item.Select(x=>x).Take(occurrenceLimit));
                }
    
                Console.WriteLine(string.Join(",",newList));
    
                Console.ReadKey();
            }
