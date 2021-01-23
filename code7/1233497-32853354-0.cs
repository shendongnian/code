    using System.Collections.ObjectModel;
    public class MenuItem
    {
        public MenuItem()
        {
            Children = new Collection<MenuItem>();
        }
        public int ID { get; set; }
        public string Caption { get; set; }
        public Collection<MenuItem> Children { get; private set; }
    }
