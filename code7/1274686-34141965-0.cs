    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ( comboBox1.Text == "Test1" || radioButton1.Checked)
        {
            StreamReader sr = new StreamReader(@"my path");
            string str = sr.ReadToEnd();
            textBox1.Text = str;
        }
    }
