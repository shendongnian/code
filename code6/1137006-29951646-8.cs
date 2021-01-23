    public static ICollection<MenuItem> MenuItems { get; set; }
    private void LoadMenuItems()
    {
        MyContext mc = new MyContext();
        this.MenuItems = ms.MenuItems.Include("SubCategories").AsNotTacking().where(x => x.SubCategory == null).ToArray();
    } 
    
    protected void Application_Start(object sender, EventArgs e)
    {
        this.MenuItems = LoadMenuItems();
    }
