    public class Item
    {
        private static int index = 0;   // for test purposes
    
        public int Distance { get; set; }
        public object Data { get; set; }
    
        public Item(int distance)
        {
            this.Distance = distance;
            this.Data = ++index;
        }
    }
