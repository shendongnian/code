    private void button1_Click(object sender, EventArgs e)
    {
        string x;
        x = textBox1.Text;
        if (!String.IsNullOrWhiteSpace(x))
        {
            some code...
        }
        else
        {
            MessageBox.Show("Please type something");
        }
    }
