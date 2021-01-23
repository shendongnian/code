    public class Box
    {
        public Box() { }
        public int BoxId { get; set; }
        public string BoxName { get; set; }
        public virtual Item Item { get; set; }
    }
       
    public class Item
    {
        public Item()
        {
            Boxes = new List<Box>();
        }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Box> Boxes { get; set; }
    }
