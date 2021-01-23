    public class MenuItemTr
    {
    
     public MenuItemTr
     {
        this.MenuItems= new List <MenuItem>
     }
    public int SiteMenuId {get; set;}
    public int ParentId {get; set;}
    public string MenuName {get; set;}
    public string Url {get; set;}
    public int SiteId {get; set;}
    public List <MenuItemTr> MenuItems {get; set;}
    }
