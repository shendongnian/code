    private void dgvList_CellFormatting(object sender,DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 || e.ColumnIndex == 8)
            {
                e.CellStyle.Format = "N2";
            }
        }
