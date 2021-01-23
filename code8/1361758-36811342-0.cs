    public class MyItems
    {
        public string ItemName { get; set; }
        public int CopyNumber { get; set; }
        public int Guid { get; set; }
        public DateTime? TimePrinted { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public bool? BestSeller { get; set; }
    
        public static explicit operator AbstractItem(MyItems myitems)
        {
            return new AbstractItem(myitems.CopyNumber, myitems.ItemName, myitems.TimePrinted, myitems.Guid);
        }
    }
