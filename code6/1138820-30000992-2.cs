    // class variable to test if have been hit twice in a row
    ListViewGroup lastHitGroup = null;
    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        // check left side to see if we are at the empty space
        ListViewItem lvi = listView1.GetItemAt(4, e.Y);
        // yes, no action! reset  group
        if (lvi != null)  { lastHitGroup = null; return; }
        // get the height of an Item
        int ih = listView1.GetItemRect(0).Height;
        // to get the group we need to check the next item:
        ListViewItem lviNext = listView1.GetItemAt(4, e.Y + ih);
        // no next item, maybe the group is emtpy, no action
        if (lviNext == null) return;
        // this is our group
        ListViewGroup editedGroup = lviNext.Group;
        // is this the 2nd time?
        if (lastHitGroup != editedGroup) {lastHitGroup = editedGroup; return;}
        // we overlay a TextBox
        TextBox tb = new TextBox();
        tb.Parent = listView1;
        // set width as you like!
        tb.Height = ih;
        // we position it over the group header and show it
        tb.Location = new Point(0, lviNext.Position.Y - ih - 4);
        tb.Show();
        // we need two events we quit editing
        tb.KeyPress += (ss, ee) =>
        {
            if (ee.KeyChar == (char)13)  // success
            {
                if (editedGroup != null && tb.Text.Length > 0)
                    editedGroup.Header = tb.Text;
                tb.Hide();
                ee.Handled = true;
            }
            else if (ee.KeyChar == (char)27)  // abort
            {
                tb.Text = ""; tb.Hide(); ee.Handled = true;
            }
           
        };
        tb.LostFocus += (ss, ee) =>  // more success
        {
           if (editedGroup != null && tb.Text.Length > 0)
              editedGroup.Header = tb.Text;
           tb.Hide();
        };
        // we need to wait a little until the group items have been selected
        Timer lvTimer = new Timer();
        lvTimer.Interval = 333;  // could take longer for a huge number of items!
        lvTimer.Tick += (ss,ee) => { tb.Focus(); lvTimer.Stop();};
        lvTimer.Start();
    }
