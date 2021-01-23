    private void button2_Click(object sender, EventArgs e)
    {
        string[] lines = System.IO.File.ReadAllLines(this.textBox2.Text);
        foreach (string line in lines)
        {
            this.listProxy.Items.Add(line);
        }
    }
