    private void mvImpSelectionBT_Click(object sender, EventArgs e)
     {
         List<DataRow> rowsToDelete = new List<DataRow>();
         foreach (DataGridViewRow item in matExpDataGridVW.Rows)
         {
            if ((bool)item.Cells[0].Value == true)
            {
                //copy row
                int n = matImpDataGridVW.Rows.Add();
                matImpDataGridVW.Rows[n].Cells[0].Value = false;
                matImpDataGridVW.Rows[n].Cells[1].Value = item.Cells[1].Value.ToString();
                matImpDataGridVW.Rows[n].Cells[2].Value = item.Cells[2].Value.ToString();
                matImpDataGridVW.Rows[n].Cells[3].Value = item.Cells[3].Value.ToString();
                matImpDataGridVW.Rows[n].Cells[4].Value = item.Cells[4].Value.ToString();
                matImpDataGridVW.Rows[n].Cells[5].Value = item.Cells[5].Value.ToString();
                //add to list
                rowsToDelete.Add(item);
            }                
        }
        foreach(DataRow row in rowsToDelete)
        {
            matExpDataGridVW.Rows.Remove(row);
        }
    } 
