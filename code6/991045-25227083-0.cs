    private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if(listBox1.SelectedItem != null)
        {
            textBox2.Text = listBox1.SelectedItem.ToString();
        }
    }
