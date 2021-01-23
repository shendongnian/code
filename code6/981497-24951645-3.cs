    ///Inserting default records
    ///The fifth column value is a primary key value
    ///Application will check that value with second grid and performs remove and add rows
    ///we cannot use row index to remove row. because the row index will be changed if any row removed from dgv2.
    ///I have placed this code in form load event.
    dgv1.Rows.Add(false, "Nimesh", "Gujarat", "India", 1);
    dgv1.Rows.Add(false, "Prakash", "MP", "India", 2);
    dgv1.Rows.Add(false, "Rohit", "Maharashtra", "India",  3);
    dgv1.Rows.Add(false, "Jasbeer", "Panjab", "India",  4);
    dgv1.Rows.Add(false, "Venkteshwar", "Karnatak", "India", 5);
    dgv1.Rows.Add(false, "Rony", "Delhi", "India", 6);
    ///We cannot use CellChange event becauase it will be executed after cell end edit.
    ///We cannot use CellContentClick event coz it will not call when you double click or clicking quickly multiple times.
    ///So we are using CellMouseUp event 
 
    private void dgv1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
    	if (dgv1.CurrentCell == null)
    		return;
    
    	dgv2.Visible = true;
    	if (dgv1.CurrentCell.ColumnIndex == 0)
    	{
    		bool bValue = (bool)dgv1.CurrentCell.GetEditedFormattedValue(e.RowIndex, DataGridViewDataErrorContexts.CurrentCellChange);
    		if (bValue)
    		{
    			for (int iRow = 0; iRow < dgv2.Rows.Count; iRow++)
    			{
    				if (dgv2.Rows[iRow].Tag != null && dgv2.Rows[iRow].Tag.Equals(dgv1.CurrentRow.Cells[4].Value))
    					return;
    			}
    			int iNewRowIndex = dgv2.Rows.Add();
    			dgv2.Rows[iNewRowIndex].Cells[0].Value = dgv1.CurrentRow.Cells[1].Value;
    			dgv2.Rows[iNewRowIndex].Cells[1].Value = dgv1.CurrentRow.Cells[2].Value;
    			dgv2.Rows[iNewRowIndex].Cells[2].Value = dgv1.CurrentRow.Cells[3].Value;
    			dgv2.Rows[iNewRowIndex].Tag = dgv1.CurrentRow.Cells[4].Value;
    		}
    		else
    		{
    			if (dgv1.CurrentRow.Cells[4].Value != null)
    			{
    				for (int iRow = 0; iRow < dgv2.Rows.Count; iRow++)
    				{
    					if (dgv2.Rows[iRow].Tag != null && dgv2.Rows[iRow].Tag.Equals(dgv1.CurrentRow.Cells[4].Value))
    					{
    						dgv2.Rows.RemoveAt(iRow);
    						break;
    					}
    				}
    			}
    		}
    	}
    }
