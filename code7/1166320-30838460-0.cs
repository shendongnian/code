    public void ListBox1_OnDoubleClick(object sender, EventArgs e)
    {
        string text = listBox1.Text; // Don't forget to manipulate with it
        Form1 form = new Form1();
        form.Show();
    }
