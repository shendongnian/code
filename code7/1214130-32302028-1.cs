    private void UpdateLayout()
    {
        if (this.listView1.View == View.LargeIcon ||
            this.listView1.View == View.SmallIcon ||
            this.listView1.View == View.Tile)
        {
            listView1.BeginUpdate();
            //Force ListView to update its content and layout them as expected
            listView1.Alignment = ListViewAlignment.Default;
            listView1.Alignment = ListViewAlignment.Top;
            listView1.EndUpdate();
        }
    }
