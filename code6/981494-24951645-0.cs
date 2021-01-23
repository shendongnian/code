    private void dataGridView6_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        dataGridView10.Visible = true;           
    	if (dataGridView6.CurrentCell.ColumnIndex == 7)
    	{
    		bool bValue = (bool)dataGridView6.CurrentCell.Value;		
    		if (bValue)
    		{
    			int iNewRowIndex = dgv2.Rows.Add();
                dgv2.Rows[iNewRowIndex].Cells[1].Value = dgv1.CurrentRow.Cells[2].Value;
                dgv2.Rows[iNewRowIndex].Cells[2].Value = dgv1.CurrentRow.Cells[3].Value;
                dgv2.Rows[iNewRowIndex].Cells[3].Value = dgv1.CurrentRow.Cells[5].Value;
                dgv1.CurrentRow.Tag = iNewRowIndex;					
    		}
    		else
    		{
    			int iRemoveIndex = Convert.ToInt32(dgv1.Tag);
    			int iRemoveIndex = Convert.ToInt32(dgv1.CurrentRow.Tag);
                dgv2.Rows.RemoveAt[iRemoveIndex];
    		}
    	}
    }
