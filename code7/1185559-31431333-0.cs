    private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DataGrid.Rows[e.RowIndex];
                txtComments.Text = row.Cells["Comments"].Value.ToString();
            }
        }
