    private void buttonListTotal_Click(object sender, EventArgs e)
    {
        TimeSpan grandtotalTime = new TimeSpan();
        foreach (ListViewItem lstItem in listView1.Items)
        {
            // Use the correct SubItems[] index for your time values, of course,
            // and not the "1" that was in your double-based code.
            grandtotalTime += TimeSpan.Parse(lstItem.SubItems[1].Text);
        }
        textBoxListTotal.Text = Convert.ToString(grandtotalTime );
    }
