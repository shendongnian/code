    protected void lstLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
         //get data into DataTable
           rp.DataSource=dt;
           rp.DataBnd();
    }
  
      protected void UpLdButton_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < tblRow; i++)
        {
             //this way you get the relevant fileUpload
            fileUp = (FileUpload)((Button)Sender).Parent.FindControl ("file);
     
        //rest of code to save file
        }
    }
