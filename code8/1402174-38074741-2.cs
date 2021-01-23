    private int whichButton = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        whichButton = 1;
        openFileDialog1.ShowDialog();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        whichButton = 2;
        openFileDialog1.ShowDialog();
    }
    private void button3_Click(object sender, EventArgs e)
    {
        whichButton = 3;
        openFileDialog1.ShowDialog();
    }
