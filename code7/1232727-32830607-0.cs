    public void btnManage_Click(object sender, EventArgs e)
    {
        ctrlManagePresets ctrl = PopulateCreateJob();
        ctrl.Dock = DockStyle.Left; 
        tableLayoutPanel.Controls.Add(ctrl, 1, 1);
    }
    public ctrlManagePresets PopulateCreateJob()
    {
        ctrlManagePresets ctrlmanagepresets = new ctrlManagePresets();
        // current code that initialize the instance of your control
        ....
        // return the control instance initialized to the caller
        return ctrlmanagepresets;
    }
