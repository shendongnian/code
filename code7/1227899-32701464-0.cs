    public class Menu
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public List<Menu> ChildMenus { get; set; }
    }
