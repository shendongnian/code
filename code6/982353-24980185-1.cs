    private void listView1_Resize(object sender, EventArgs e)
    {
        int oldsum = 0;
        foreach (ColumnHeader ch in listView1.Columns) oldsum += ch.Width;
        foreach (ColumnHeader ch in listView1.Columns)
        {
            if (ch.Tag != "#") ch.Width = ch.Width * listView1.ClientSize.Width / oldsum;
        }
    }
