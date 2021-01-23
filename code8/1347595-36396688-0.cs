    namespace LoginNavigation
    {
    public class RootPage:MasterDetailPage
    {
    MenuPage menuPage;
    public RootPage ()
    {
    
    menuPage = new MenuPage ();
    
    menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItemForMaster);
    
    Master = menuPage;
    Detail = new NavigationPage (new TimeSheet()){
    };
    }
    
    void NavigateTo (MenuItemForMaster menu)
    {
    if (menu == null)
    return;
    
    Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);
    //Detail = displayPage;
    Detail = new NavigationPage (displayPage) { BarBackgroundColor = Color.FromHex("008dce"),BackgroundColor  = Color.FromHex("008dce")};
    
    menuPage.Menu.SelectedItem = null;
    IsPresented = false;
    }
    }
    }
