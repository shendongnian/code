    private void Form1_Load(object sender, EventArgs e)
    {
        listBox1.Items.Add("");
    }
    private void buttonUnlock_Click(object sender, EventArgs e)
    {
        listBox1.Items[0] = listBox1.Items[0].ToString().Replace("", "");
    }
    private void buttonAppend_Click(object sender, EventArgs e)
    {
        listBox1.Items[0] += "";
    }
