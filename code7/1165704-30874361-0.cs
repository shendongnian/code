    boolean flag=false
        
    public void BindCombobox()
    {
    	Software pd = new Software();
        DataSet dsProj = pd.UserID();
        flag=false;
        cbValue.DataSource = dsProj.Tables[0];//Calling SelectedindexChange
        cbValue.DisplayMember = "ProjectName";
        cbValue.ValueMember = "ProjectID";
        flag=true;
    }
        
    private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(flag==true)
        {
    		... //rest of the code
        }
    }
