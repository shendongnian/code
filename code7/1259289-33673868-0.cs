    private void timer1_Tick(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listView1.Items)
        {
            var timeSpan = ((DateTime)item.Tag) - DateTime.Now;
            item.SubItems[2].Text = string.Format("{0}h {1}m {2}s",
                 timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
    }
