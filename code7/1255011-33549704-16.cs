    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
            return;
        if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
        {
            var image = Properties.Resources.DeleteImage; //An image
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            var x = e.CellBounds.Left + (e.CellBounds.Width - image.Width) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - image.Height) / 2;
            e.Graphics.DrawImage(image, new Point(x, y));
            e.Handled = true;
        }
    }
