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
                case (int)SomeIdConstants.FIRST: return 1;
                case (int)SomeIdConstants.SECOND: return 2;
                case (int)SomeIdConstants.THIRD: return 3;
                case (int)SomeIdConstants.FOURTH: return 4;
                case (int)SomeIdConstants.FIFTH: return 5;
                default: return 999;
            }
        }
    }
    public enum SomeIdConstants : int
    {
        FIRST = 2,
        SECOND = 1,
        THIRD = 4,
        FOURTH = 5,
        FIFTH = 3
    }
