    protected void btnGetControlIds_Click(object sender, EventArgs e)
    {
        GetControlIds(phMyStuff);
    }
    
    private void GetControlIds(Control parent) 
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl is TextBox || ctrl is CheckBox)
            {
                Response.Write(ctrl.ID);
            }
            else
            {
                if (ctrl.HasControls())
                {
                    GetControlIds(ctrl);
                }
            }
        }
    }
