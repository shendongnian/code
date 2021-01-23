    private void listView1_MouseMove(object sender, MouseEventArgs e)
    {
        ListViewHitTestInfo HI = listView1.HitTest(e.Location);
        if (HI.SubItem != null && HI.SubItem.Name == "Link")
        {
            if (CurrHitRow != LastHitRow) LastHitRow = CurrHitRow;
            CurrHitRow = HI.Item.Index;
            if (LastHitRow >= 0 && CurrHitRow != LastHitRow) 
                listView1.Invalidate();
            Cursor = Cursors.Hand; 
        }
        else Cursor = Cursors.Default;
        curMouse = e.Location;
    }
