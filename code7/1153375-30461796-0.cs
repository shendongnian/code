    //Form1
    public void RefreshWork()
    {
    // Do Something Here
    }
    btnAdd_Click(object sender, EventArgs e)
    {
    AddData TempForm = new AddData();
    TempForm.Owner = this;
    TempForm.ShowDialog();
    }
    
    // "AddData" form
    
    AddData_FormClosing(object sender, EventArgs e)
    {
    ((Form1)Owner).RefreshWork();
    }
