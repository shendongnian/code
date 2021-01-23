    private void btnOK_Click(object sender, EventArgs e)
    {
        int count = listView1.Items.Count;
        for (int i = 0; i < count; i++)
        {
            ListViewItem lvi = listView1.Items[listView1.Items.Count - 1];
            listView1.Items.Remove(lvi);
            listView2.Items.Add(lvi);
        }
    }
