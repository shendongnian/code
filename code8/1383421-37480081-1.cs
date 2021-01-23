    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int x = 0;
        Int32.TryParse(comboBox1.SelectedText, out x);
        int count = listBox1.Items.Count;
        if (count > x)
        {
            listBox1.Items.Clear();
            int difference = count - x;
            for(int i = 0 ; i < difference ; i++)
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count-1);
            }
        }
    }
