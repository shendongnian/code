    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        if (e.ColumnIndex != 1) e.DrawDefault = true;
        else 
        {
            ListViewHitTestInfo HI = listView1.HitTest(curMouse);
            if (HI.Item == null) { e.DrawDefault = true; return; }
            bool showLink = e.SubItem.Text.Substring(0,4) == "Link" 
                         && e.Item.Index == HI.Item.Index;
            e.DrawBackground();
            using (Font font = new Font(listView1.Font, showLink ?
                                        FontStyle.Underline : FontStyle.Regular))
            {
                e.Graphics.DrawString(e.SubItem.Text, font, showLink ?
                  SystemBrushes.HotTrack : SystemBrushes.ControlText, e.Bounds);
            }
        }
    }
