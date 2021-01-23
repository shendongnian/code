    private Control FindControl(Control parent, string ctlName)
    {
        foreach(Control ctl in parent.Controls)
        {
            if(ctl.Name.Equals(ctlName))
            {
                return ctl;
            }
    
            FindControl(ctl, ctlName);                     
        }
        return null;
    }
    
