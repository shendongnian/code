    private void button7_Click(object sender, EventArgs e)
    {
         lblTotal1.Text = calc(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
    }
    // Note the changed calc parameters
    private void calc(string TextBox1, string TextBox2, string TextBox3, string TextBox4, string TextBox5, string TextBox6, string TextBox7, string TextBox8)
    {
        // Same code as original but change last line to
        return Total.ToString();
    }
