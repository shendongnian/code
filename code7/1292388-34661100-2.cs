    for (int i = matExpDataGridVW.Rows.Count - 1; i >= 0; i--) 
    {
         if ((bool)matExpDataGridVW.Rows[i].Cells[0].Value == true)
            {
                //copy row
                int n = matImpDataGridVW.Rows.Add();
                matImpDataGridVW.Rows[n].Cells[0].Value = false;
                matImpDataGridVW.Rows[n].Cells[1].Value = matExpDataGridVW.Rows[i].Cells[1].Value.ToString();
                matImpDataGridVW.Rows[n].Cells[2].Value = matExpDataGridVW.Rows[i].Cells[2].Value.ToString();
                matImpDataGridVW.Rows[n].Cells[3].Value = matExpDataGridVW.Rows[i].Cells[3].Value.ToString();
                matImpDataGridVW.Rows[n].Cells[4].Value = matExpDataGridVW.Rows[i].Cells[4].Value.ToString();
                matImpDataGridVW.Rows[n].Cells[5].Value = matExpDataGridVW.Rows[i].Cells[5].Value.ToString();
                //delete row
                matExpDataGridVW.Rows[i].Delete();
         }
         matExpDataGridVW.AcceptChanges();
    }
