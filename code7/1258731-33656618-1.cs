    int lastIndex = 0;
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = listBox1.SelectedItem.ToString();
        int newIndex = listBox1.SelectedIndex;
        if (s == "" )
        {
            if (newIndex > lastIndex && newIndex  < listBox1.Items.Count)
            {
                listBox1.SelectedIndex++;
            }
            else if (newIndex < lastIndex && newIndex > 0)
            {
                listBox1.SelectedIndex--;
            }
        }
        else lastIndex = newIndex;
    }
