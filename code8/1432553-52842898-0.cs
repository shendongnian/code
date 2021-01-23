    MouseEventArgs b = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 2, 
        MousePosition.X, MousePosition.Y, 0);
    DataGridViewCellMouseEventArgs a = new DataGridViewCellMouseEventArgs(0, 0, 
        MousePosition.X, MousePosition.Y, b);
    dataGridView1_CellMouseDoubleClick(sender, a);
