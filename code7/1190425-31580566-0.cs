    class Program
    {
        static void Main(string[] args)
        {
            var originalList = CreateOriginalList();// Original List
            List<Item> MyListDeepCopy = new List<Item>();// Empty List
            // Copy Original List to MyListDeepCopy if later is empty.
            if (MyListDeepCopy.Count() == 0)
                MyListDeepCopy = (List<Item>)originalList;
            {
                /* DELETE IF FOUND */
                int dItemId = 11;
                // Update originalList
                originalList.RemoveAll(d => d.ItemId == dItemId);
                // Update same in MyListDeepCopy
                MyListDeepCopy.RemoveAll(d => d.ItemId == dItemId);
            }
            {
                /* ADD IF NOT EXIST ELSE UPDATE */
                int aItemId = 17;
                double aItemPrice = 1200;
                // ADD to originalList
                originalList.Add(new Item { ItemId = aItemId, ItemPrice = aItemPrice });
                // Update 
                if (MyListDeepCopy.Exists(a => a.ItemId == aItemId))
                    (MyListDeepCopy.FirstOrDefault(o => o.ItemId == aItemId)).ItemPrice = aItemPrice;
                else
                    MyListDeepCopy.Add(new Item { ItemId = aItemId, ItemPrice = aItemPrice });
            }          
        }
        private static List<Item> CreateOriginalList()
        {
            return new List<Item> 
            {
                new Item{ ItemId = 11, ItemPrice = 100},
                new Item{ ItemId = 12, ItemPrice = 1000},
                new Item{ ItemId = 13, ItemPrice = 1050},
                new Item{ ItemId = 14, ItemPrice = 600},
                new Item{ ItemId = 15, ItemPrice = 900}
            };            
        }
    }
    public class Item
    {
        public int ItemId{get; set;}
        public double ItemPrice { get; set; }
        public override string ToString()
        {
            return string.Format("{0}  :  {1}", ItemId, ItemPrice);
        }
    }
