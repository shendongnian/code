    void buttonSave_Click(object sender, EventArgs e)
    {
         DataSet ds = grdVisPay.DataSource as DataSet;
         DataRows[] selectedRows = ds.Tables[0].Select("Select = True");
         foreach(DataRow row in selectedRows)
         {
             ... do whatever you need with the selected row...
             
         }
    }
 
