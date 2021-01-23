    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
            return;
        if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            var x = e.CellBounds.Left + (e.CellBounds.Width - Properties.Resources.DeleteImage.Width) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - Resources.DeleteImage.Height) / 2;
            e.Graphics.DrawImage(Properties.Resources.DeleteImage, new Point(x, y));
            e.Handled = true;
        }
    }
