    private void panel1_DragEnter(object sender, DragEventArgs e)
    {
        // we indicate that we allow dropping
        e.Effect = DragDropEffects.Copy;
    }
    private void panel1_DragDrop(object sender, DragEventArgs e)
    {
        // the mousemove has packed a row as data, so we unpack it:
        DataGridViewRow row = e.Data.GetData( typeof(DataGridViewRow)) as DataGridViewRow;
        // not sure what to do with it - store it in the tag
        panel1.Tag = row;
        // let the paint show something
        panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        // if we hava data in the tag we cast them to DataGridViewRow..
        // ..and display the content of the 2nd cell
        if (panel1.Tag != null)
            e.Graphics.DrawString( ((DataGridViewRow)panel1.Tag).Cells[1].Value.ToString(), 
                                    this.Font, Brushes.DarkRed, 8, 8);
    }
