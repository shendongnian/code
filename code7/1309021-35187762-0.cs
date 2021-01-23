    private void button1_Click(object sender, EventArgs e)
    {
           String name = this.textBox1.Text;
           int testNumber = int.Parse(textBox2.Text);
           submittedTests.Add(this.textBox1.Text, testNumber);
        foreach (var x in submittedTests)
        {
            listBox1.Items.Add(x.Key + " " + x.Value);
        }
    }
