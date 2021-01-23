    private void datagridviewResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.datagridviewResult.Rows[e.RowIndex];
                txtGenerateId.Text = string.Format("{0},{1}", 
                    row.Cells["M_ID"].Value.ToString(),
                    row.Cells["A_ID"].Value.ToString()); 
              
            }
        }
