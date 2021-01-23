    class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<MyItem>
            { 
                new MyItem { SomeId = 1 },
                new MyItem { SomeId = 2 },
                new MyItem { SomeId = 3 },
                new MyItem { SomeId = 4 },
                new MyItem { SomeId = 5 }
            };
            var orderedList = myList.OrderBy(d => d, new MyItemComparer());
            foreach (var listItem in orderedList)
            {
                Console.WriteLine(listItem.SomeId);
            }
            Console.ReadLine();
        }
    }
    public class MyItem
    {
        public int SomeId { get; set; }
    }
    public class MyItemComparer : IComparer<MyItem>
    {
        public int Compare(MyItem i1, MyItem i2)
        {
            int pos1 = pos(i1);
            int pos2 = pos(i2);
            if (pos1 > pos2) { return 1; }
            if (pos1 < pos2) { return -1; }
            return 0;
        }
        // Return the required position for a value of SomeId
        private int pos(MyItem it)
        {
            switch (it.SomeId)
            {
                case 1: return 2;
                case 2: return 1;
                case 3: return 5;
                case 4: return 3;
                case 5: return 4;
                default: return 999;
            }
        }
    }
