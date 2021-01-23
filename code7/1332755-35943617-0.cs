    private void itemToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var i = ((Control)sender.Tag) as Item;
        this.i = new Item();
        this._Items.Add(i);
        // you dynamically create a control and set the Tag property
        someControl.Tag = i;
        this.Refresh();
    }
    private void tekenVel_MouseDown(object sender, MouseEventArgs e)
    {
        var i = ((Control)sender.Tag) as Item;
        if(i!=null)
        {
            i.note = Color.Azure;
            isMouseDown = true;
        }
    }
    private void tekenVel_MouseMove(object sender, MouseEventArgs e)
    {
        if (isMouseDown == true)
        {
                i.X = e.X;
                i.Y = e.Y;
                Refresh();
        }
    }
