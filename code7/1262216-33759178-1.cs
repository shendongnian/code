    private void equals_Click(object sender, EventArgs e)
    {
        Result.Text = new System.Data.DataTable().Compute(Sum.Text, null);    
    }   
  
