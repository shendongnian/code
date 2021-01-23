    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        // disassociate from listview at first:
        listView1.ContextMenuStrip = null;
        // check for right button
        if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
        // get item info:
        ListViewHitTestInfo hi = listView1.HitTest(e.Location);
        // no item hit:
        if (hi.Item == null) return;
        // calculate the image rectangle:
        // this contains the unscrolled y coordinate:
        Point iloc = listView1.GetItemRect(hi.Item.Index).Location;
        // we combine it with the x-position:
        Rectangle r = new Rectangle(new Point (hi.Item.Position.X,  iloc.Y),
                                    imageList1.ImageSize);
        // no image hit:
        if ( !r.Contains(e.Location) ) return;
        // maybe prepare or change the menue now..
        // here I display the image name from the keys array:
        ms.Items[0].Text = imageList1.Images.Keys[hi.Item.ImageIndex];
        ms.Location = e.Location;
        // associate with listview and show
        listView1.ContextMenuStrip = ms;
        ms.Show();
    }
