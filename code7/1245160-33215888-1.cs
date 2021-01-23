    protected void Page_Load(object sender, EventArgs e)
    {
      MyUserControl uc = (MyUserControl)LoadControl("MyUserControl.ascx");
      Controls.Add(uc);
    
      MyClass c = new MyClass(uc);
      c.MyClassMethod();
    }
