    private static void Main(string[] args)
        {
           
            string[] first = {"One", "Two", "Three", "Three", "Three"};
            string[] second = {"One", "Two", "Four", "Three"};
            var result = FirstExceptSecond(first, second);
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
        }
        private static IEnumerable<string> FirstExceptSecond(IList<string> first, IList<string> second)
        {
            List<string> firstList = new List<string>(first);
            List<string> secondList = second as List<string> ?? second.ToList();
            foreach (string s in secondList)
            {
                if (firstList.Contains(s))
                {
                    firstList.Remove(s);
                }
            }
            return firstList;
        } 
