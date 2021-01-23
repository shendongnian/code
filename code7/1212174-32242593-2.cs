    private void button1_Click(object sender, EventArgs e)
    {
         listView1.Items[0].SubItems.Add("ABC");
         Console.WriteLine("Item 0 has " + listView1.Items[0].SubItems.Count + " subitems.);
    }
