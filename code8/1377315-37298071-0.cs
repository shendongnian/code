    public class MenuItem
    {
         public int Id { get; set; }
         public bool Divider { get; set; }
         public bool Header { get; set; }
         public string ActionName { get; set; }
         public string ControllerName { get; set; }
         public string MenuItemText { get; set; }
         public string Title { get; set; }
         public IList<string> Roles { get; set; }
         public int ParentId { get; set; }
    }
    var MenuList = new List<MenuItem>();
    var menuItem = new MenuItem
    {
        Id = 1,
        Divider = true,
        Header = true,
        ActionName = "Scheduling",
        ControllerName = "Index",
        MenuItemText = "sdfs",
        Title = "Scheduling",
        Roles = new List<string>{"rol1", "rol2"},
        ParentId = 30
    };
    MenuList.Add(menuItem);
