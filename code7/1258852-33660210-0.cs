    private void Form1_Load(object sender, EventArgs e)
    {
        string[] someList = Properties.Settings.Default.myList.Split('|');
        listBox1.Items.AddRange(someList);
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        string[] someList = new string[listBox1.Items.Count];
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            someList[i] = (string)listBox1.Items[i];
        }
        Properties.Settings.Default.myList = string.Join("|", someList);
        Properties.Settings.Default.Save();
    }
