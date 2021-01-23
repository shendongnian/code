    private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        var rowItem = (DataRowView)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
        int index = ((this.dataGridView1.DataSource as BindingSource).DataSource as DataTable).Rows.IndexOf(rowItem.Row);
        using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
        {
            e.Graphics.DrawString((index + 1).ToString(), e.InheritedRowStyle.Font, b,
            e.RowBounds.Location.X + 10,
            e.RowBounds.Location.Y + 4);
        }
    }
