    private void btnClose_Click(object sender, EventArgs e)
        {        
    
       if (MessageBox.Show("Do you want to save changes to the data?",
                        "MktAuthorizationData", 
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
           {
            e.Cancel = true;
            // Do Something 
           }
       } 
