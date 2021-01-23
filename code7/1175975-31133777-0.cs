    private void lvInfo_MouseUp(object sender, MouseEventArgs e)
    {
        this.X = e.X;
        this.Y = e.Y;
    }
    private void lvInfo_DoubleClick(object sender, EventArgs e)
    {
        // if double clicked on gas column open dialog for entering new gas value
        Point mousePos = new Point(this.X,this.Y);
        ListViewHitTestInfo info = lvInfo.HitTest(mousePos);
        int colNr = info.Item.SubItems.IndexOf(info.SubItem);
        if (colNr == 7)
        {
            MessageBox.Show("Test");
            
        }
    }
