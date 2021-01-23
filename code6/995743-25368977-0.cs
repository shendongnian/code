    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (this.Master is Site)
        {
            ((Site)this.Master).MyButtonCallBack = DoSomething;
        }
    }
    
    private void DoSomething() 
    {
        //...
    }
