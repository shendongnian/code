    class DgvTools
    {
      public static void MoveRow(DataGridView dgv, int dgvRowIndex0, int dgvRowIndex1)
      {
        if (dgv.Rows != null)
           if (dgv.DataSource != null)
           {
                    DataTable dt = null;
                    if (dgv.DataSource is BindingSource)
                    {
                        dt = (DataTable)((BindingSource)dgv.DataSource).DataSource;
                    }else if (dgv.DataSource is DataTable)
                    {
                        dt = (DataTable)dgv.DataSource;
                    }
                                    
                    DataRow row0 = ((DataRowView)dgv.Rows[dgvRowIndex0].DataBoundItem).Row;
                    int row0Index =  dt.Rows.IndexOf(row0);
                             
                    DataRow row1 = ((DataRowView)dgv.Rows[dgvRowIndex1].DataBoundItem).Row;
                    int row1Index =  dt.Rows.IndexOf(row1);
                    MoveRow(dt, row0Index, row1Index);
          }
       }
    
       public static void MoveRow(DataTable dt, int row0Index, int row1Index)
       {
            if (dt != null)
            {
                int lowIndex = Math.Min(row0Index, row1Index);
                int highIndex = Math.Max(row0Index, row1Index);
                if (dt.Rows.Count >= 2)
                    if (lowIndex != highIndex)
                        if ((lowIndex >= 0) && (highIndex < dt.Rows.Count))
                        {
                            DataRow oldRow = dt.NewRow();
                            oldRow.ItemArray = dt.Rows[lowIndex].ItemArray;
                            dt.Rows.Remove(dt.Rows[lowIndex]);
                            dt.Rows.InsertAt(oldRow, highIndex);
                        }
            }
       }
    }
