    if (!Page.IsPostBack)
    {
       filldropdown(dllselection.SelectedValue);
    }
    Code.Enabled = true;
    if(dllselection.SelectedValue=="")
    {
            Code.Enabled = false;
    }
