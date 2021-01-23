    public static void Main(string[] args)
        {
            var activeList = new List<string> { "A" };
            var userList = new List<string> {"A", "B", "C"};
            var removalList = userList.Except(activeList);
            foreach (var item in removalList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();    
        }
