    private void Form1_Load(object sender, EventArgs e)
    {
        listBox1.SelectionMode = SelectionMode.MultiExtended;
        ...
    }
    private void button1_Click(object sender, EventArgs e)
    {
        antras.Clear();
        foreach(int index in listBox1.SelectedIndices)
            antras.Add(pradinis[listBox1.SelectedIndex]);
    }
