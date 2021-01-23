	class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 3, 5, 2, 4, 6 };
            var subList = new List<int> { 3, 5};
            var subList2 = new List<int> { 1, 4 };
            bool isSublist1 = subList.IsSubset(list);
            bool isSublist2 = subList2.IsSubset(list);
            Console.WriteLine(isSublist1 + "; " + isSublist2);
            Console.ReadKey();
        }
    }
