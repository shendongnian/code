    private void Form1_Load(object sender, EventArgs e)
    {
        DirectoryInfo dir = new DirectoryInfo(".\\Notes\\");
        FileInfo[] files = dir.GetFiles("*.txt");
        foreach ( FileInfo file in files )
        {
            listBox1.Items.Add(file);
        }
    }
    //Or in a Button_Click event
    private void button1_Click(object sender, EventArgs e)
    {
        DirectoryInfo dir = new DirectoryInfo(".\\Notes\\");
        ....
    }
