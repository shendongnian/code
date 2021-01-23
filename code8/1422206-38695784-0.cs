    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 1)
        {
            if (e.Button == MouseButtons.Left)
            {
                Size dgvSz = dataGridView1.ClientSize;
                int rw = dataGridView1.SelectedRows[0].Index;
                Rectangle RowRect = dataGridView1.GetRowDisplayRectangle(rw, true);
                using (Bitmap bmp2 = new Bitmap(RowRect.Width, RowRect.Height))
                using (Bitmap bmp = new Bitmap(dgvSz.Width, dgvSz.Height))
                {
                    dataGridView1.DrawToBitmap(bmp, new Rectangle(Point.Empty, dgvSz));
                    using ( Graphics G = Graphics.FromImage(bmp2))
                        G.DrawImage(bmp, new Rectangle(Point.Empty, 
                                    RowRect.Size), RowRect, GraphicsUnit.Pixel);
                Cursor cur = new Cursor(bmp2.GetHicon());
                Cursor.Current = cur;
                rowIndexFromMouseDown = dataGridView1.SelectedRows[0].Index;
                dataGridView1.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }
    }
