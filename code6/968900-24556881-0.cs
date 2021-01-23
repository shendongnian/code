    private void myDataDridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
             try
             {
                  // Your update query here
             }
             catch (Exception ex)
             {
                  MessageBox.Show(ex.Message);
             }
        }
