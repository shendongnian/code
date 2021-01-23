    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (listBox2.Items.Count >= listBox1.SelectedIndex + 1)
         {
              listBox2.SelectedIndex = listBox1.SelectedIndex;
         }
    }
    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox1.Items.Count >= listBox2.SelectedIndex + 1)
        {
             listBox1.SelectedIndex = listBox2.SelectedIndex;               
        }
    }
