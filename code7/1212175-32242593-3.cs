    private void button2_Click(object sender, EventArgs e)
    {
        int someindex = 4;
        foreach (ListViewItem lvi in listView1.Items)
            if (lvi.SubItems.Count - 1 > someindex && lvi.SubItems[someindex] != null)
            {
                lvi.SubItems.RemoveAt(someindex);
                Console.WriteLine("Subitem " + someindex + " removed in Item " + lvi.Index);
            }
    }
