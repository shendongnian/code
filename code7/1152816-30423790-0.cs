    static void PaintGrouped(DataGridView dgv)
    {
        if (dgv.Rows.Count < 2) return;
        if (dgv.Columns.Count < 2) return;
        for (int row = 1; row < dgv.Rows.Count; row++)
        {
            bool suppressing = dgv[0, row].Value.Equals(dgv[0, row - 1].Value);
            for (int col = 1; col < dgv.Columns.Count; col++)
            {
                bool equal = dgv[col, row].Value.Equals(dgv[col, row - 1].Value);
                suppressing = suppressing && equal;
                dgv[col, row].Style.ForeColor = supressing ? Color.Transparent : Color.Black;
            }
        }
    }
