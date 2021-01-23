    private void tDeletebtn_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex != -1)
        {
            System.IO.File.Delete(listBox1.Items[listBox1.SelectedIndex].ToString());
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
