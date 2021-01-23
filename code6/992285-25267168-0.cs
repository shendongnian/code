    private void button1_Click(object sender, EventArgs e)
    {
        string txt_string = this.textBox1.Text.ToString();
        if (txt_string == null)
            MessageBox.Show("Yes");
        else
            MessageBox.Show("No");
    }
