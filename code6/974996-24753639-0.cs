    protected void Page_Load(object sender, EventArgs e) 
    {
        //call your function
        display(); 
    }
    protected void Page_PreRender(object sender, EventArgs e) 
    {
        //call your function even later in the page life cycle
        display(); 
    }
    public void display()
    {
      // some block statements
    }
