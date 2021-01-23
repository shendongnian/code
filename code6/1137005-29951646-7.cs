    public static ICollection<MenuItem> MenuItems {
        get
        {
            if (Application["MenuItems"] != null)
                return (ICollection<MenuItems>)Application["MenuItems"];
            else
                return new ICollection<MenuItems>();
        }
        set
        {
            Application["MenuItems"] = value;    
        }
    }
    private void LoadMenuItems()
    {
        MyContext mc = new MyContext();
        this.MenuItems = ms.MenuItems.Include("SubCategories").AsNotTacking().where(x => x.SubCategory == null).ToArray();
    } 
    
    protected void Application_Start(object sender, EventArgs e)
    {
        this.MenuItems = LoadMenuItems();
    }
