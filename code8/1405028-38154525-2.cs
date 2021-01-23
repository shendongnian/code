    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
        using (var pen = new Pen(this.dataGridView1.GridColor, e.CellStyle.Padding.All))
            e.Graphics.DrawRectangle(pen, e.CellBounds);
        e.Handled = true;
    }
