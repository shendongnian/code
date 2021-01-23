    if (e.ColumnIndex == dataGridView_1.Columns["Selected"].Index)
        if (Convert.ToInt16(dataGridView_1.Rows[e.RowIndex].Cells[0].Value) == 1)
        {
            foreach (DataGridViewRow DR in dataGridView_PrimeMover.Rows)
            {
                if((int)DR.Columns["Selected"] == 1 && DR.Index != e.RowIndex)
                    DR.Columns["Selected"] = 0;
            }
       }
