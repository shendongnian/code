    private void tsmNewEmp_Click(object sender, EventArgs e)
    {
    	if(NewEmp == null)
    	{
    		NewEmp = new NewEmployee();
    		NewEmp.MdiParent = this;
    		NewEmp.FormClosed += FormClosed_1;
    	}
    	NewEmp.Show();
    	tsmNewEmp.Enabled = false;
    	tsmNewContract.Enabled = false;
    }
    
    private void FormClosed_1(object sender, FormClosedEventArgs e)
    {
    	tsmNewEmp.Enabled = true;
    	tsmNewContract.Enabled = true;
    }
