        private void eolGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int rowNum = e.RowIndex;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DateTime dateval = Convert.ToDateTime(eolGrid.Rows[rowNum].Cells[3].Value);
            if ((dateval - date).TotalDays <= 0)
                style.ForeColor = Color.Red;
            else if ((dateval - date).TotalDays <= 14)
                style.BackColor = Color.Red;
            else
                style.ForeColor = Color.Black;
            eolGrid.Rows[rowNum].Cells[3].Style = style;
        }
