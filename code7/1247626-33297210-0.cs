    if (cell == null)
               {
                    return;
               }
    else 
       {
                Guid primaryProblem = new Guid(dataGridView2.Rows[e.RowIndex].Cells[dataGridView2.Columns["PrimaryKeyProblem"].Index].Value.ToString());
                cell.DataSource = dbCalling.getPrimaryKeyProblemDescription(primaryProblem);
                cell.DisplayMember = "Name";
                cell.ValueMember = "Id";
       }
