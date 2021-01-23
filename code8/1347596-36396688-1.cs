    namespace LoginNavigation
    {
    public class MenuListView : ListView
    {
    public MenuListView ()
    {
    List<MenuItemForMaster> data = new MenuListData ();
    
    ItemsSource = data;
    VerticalOptions = LayoutOptions.FillAndExpand;
    BackgroundColor = Color.Accent;
    
    var cell = new DataTemplate (typeof(MenuCell));
    //cell.SetBinding (MenuCell.TextProperty, "Title");
    //cell.SetBinding (MenuCell.ImageSourceProperty, "IconSource");
    this.HasUnevenRows = false;
    ItemTemplate = cell;
    }
    namespace LoginNavigation
    {
    public class MenuListData : List<MenuItemForMaster>
    {
    public MenuListData ()
    {
    this.Add (new MenuItemForMaster () { 
    Name = “"
    ImageSource = "paper_plane.png", 
    TargetType = typeof(TimeSheet)
    });
    this.Add (new MenuItemForMaster () { 
    Name = "Extn : 3969", 
    ImageSource = "phone_reciever.png", 
    TargetType = typeof(TimeSheet)
    });
    this.Add (new MenuItemForMaster () { 
    Name = "TimeSheet", 
    ImageSource = "Calender.png", 
    TargetType = typeof(TimeSheet)
    });
    
    this.Add (new MenuItemForMaster () { 
    Name = "Omega", 
    ImageSource = "Notes.png", 
    TargetType = typeof(Omega)
    });
    
    }
    }
    }
