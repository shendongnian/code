        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            try 
                { 
                    var bindData = (BindingSource)studentGridView.DataSource;
                    var dataTable = (DataTable)bindData.DataSource;
                    var rows = dataTable.Select (string.Format("Student_Username LIKE '%{0}%' AND [Some other filter]", SearchTxt.Text ));
                    studentGridView.DataSource = rows.CopyToDataTable()
                    studentGridView.Refresh();
                }
            catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
