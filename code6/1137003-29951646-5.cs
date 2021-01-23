    public class CustomHttpApplication : HttpApplication
    {
        public static ICollection<MenuItem> MenuItems { get; set; }
        private void LoadMenuItems()
        {
            MyContext mc = new MyContext();
            this.MenuItems = ms.MenuItems.where(x => x.SubCategory == null).ToArray();
        } 
    }
