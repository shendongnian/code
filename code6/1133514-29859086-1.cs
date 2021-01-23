    void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (grid.Columns[e.ColumnIndex].Name == "ControlNum")
        {
            if (e.Value != null)
            {
                int controlnum;
                if (!int.TryParse((String)e.Value, out controlnum) || (controlnum < 1))
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }
    }
