    private void listView1_MouseMove(object sender, MouseEventArgs e)
    {
        ListViewHitTestInfo HI = listView1.HitTest(e.Location);
        if (HI.SubItem != null && HI.SubItem.Name == "Link")
             Cursor = Cursors.Hand;
        else Cursor = Cursors.Default;
    }
    private void listView1_MouseUp(object sender, MouseEventArgs e)
    {
        ListViewHitTestInfo HI = listView1.HitTest(e.Location);
        if (HI.SubItem != null && HI.SubItem.Name == "Link")
            MessageBox.Show("You have clicked on " + HI.SubItem.Tag.ToString());
        // do your stuff instead!
    }
