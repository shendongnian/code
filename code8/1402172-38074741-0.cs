    private string textToPass = "";
    private void button1_Click(object sender, EventArgs e)
    {
        testToPass = this.textBox1.Text;
        openFileDialog1.ShowDialog();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        testToPass = this.textBox2.Text;
        openFileDialog1.ShowDialog();
    }
    private void button3_Click(object sender, EventArgs e)
    {
        testToPass = this.textBox3.Text;
        openFileDialog1.ShowDialog();
    }
