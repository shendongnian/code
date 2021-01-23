    void radListView1_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
    {
        string text = "";
        foreach (ListViewDataItem item in radListView1.CheckedItems)
        {
            text += item.Text + ", ";
        }
    radLabel1.Text = text;
    }
