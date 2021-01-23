    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex<0 && e.ColumnIndex<0)
            {
                e.Graphics.DrawImage(myImage, e.CellBounds);
                e.Handled = true;
            }
        }
