    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 1)
        {
            if (e.Button == MouseButtons.Left)
            {
                Size dgvSz = dataGridView1.ClientSize;
                int rw = dataGridView1.SelectedRows[0].Index;
                Rectangle RowRect = dataGridView1.GetRowDisplayRectangle(rw, true);
                using (Bitmap bmpDgv = new Bitmap(dgvSz.Width, dgvSz.Height))
                using (Bitmap bmpRow = new Bitmap(RowRect.Width, RowRect.Height))
                {
                    dataGridView1.DrawToBitmap(bmpDgv , new Rectangle(Point.Empty, dgvSz));
                    using ( Graphics G = Graphics.FromImage(bmpRow ))
                        G.DrawImage(bmpDgv , new Rectangle(Point.Empty, 
                                    RowRect.Size), RowRect, GraphicsUnit.Pixel);
                    Cursor.Current.Dispose();   // not quite sure if this is needed
                    Cursor cur = new Cursor(bmpRow .GetHicon());
                    Cursor.Current = cur;
                    rowIndexFromMouseDown = dataGridView1.SelectedRows[0].Index;
                    dataGridView1.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }
    }
