    public void PreAnaestheticChecklist_Load(object sender, EventArgs e)
    {
        this.main = (Form1)this.Owner;
        //load any values already on main form into respective textboxes
        txtProcName.Text = getProcedure();
        txtPlannedProc.Text = getProcedure();
    }
    
