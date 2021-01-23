    public class Item
    {
        public int itemid { get; set; }
        public string Item_Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
    public class User
    {
        public string userid { get; set; }
        public string User_Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
