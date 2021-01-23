    private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            try 
            { 
               
		    var bindData = (BindingSource)studentGridView.DataSource;
        	var dataTable = (DataTable)bindData.DataSource;
	        dataTable.DefaultView.RowFilter = string.Format(""Student_FName LIKE '%{0}%'", SearchTxt.Text);    
        	studentGridView.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
