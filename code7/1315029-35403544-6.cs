    private void Form_Load(object sender, EventArgs e)
    {
    	radGridView1.AllowEditRow = false;
    	radGridView1.AllowAddNewRow = true;
    	radGridView1.AllowDeleteRow = false;
    	radGridView1.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Top;
    
    	radGridView1.MasterTemplate.AddNewBoundRowBeforeEdit = true;
    	radGridView1.EnableAlternatingRowColor = true;
    }
