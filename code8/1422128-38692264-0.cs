    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            filldropdown(dllselection.SelectedValue);       
        }
    
    if(!Page.IsPostBack){
           Code.Enabled = true;
            if(dllselection.SelectedValue=="")
            {
                Code.Enabled = false;
            }
    }
    
    }
