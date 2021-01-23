        MasterPage master = this.Master;
        UserControl userControl = (UserControl)master.FindControl("userControlName");
        if(userControl != null)
    {
        master.Controls.Remove(userControl );
    }
