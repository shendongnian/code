    private void tDeletebtn_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex != -1)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            System.IO.File.Delete(listBox1.SelectedItem.ToString());
        }
    }
