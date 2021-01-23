    lbltxt.Visible = false;
    while (ListBox2.Items.Count != 0)
    {
        for (int i = 0; i < ListBox2.Items.Count; i++)
        {
            ListBox1.Items.Add(ListBox2.Items[i]);
            ListBox2.Items.Remove(ListBox2.Items[i]);
        }
    }
}
