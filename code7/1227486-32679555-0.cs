    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int numb1;
        if(Int32.TryParse(textBox1.Text, out numb1))
            textBox2.Text = textBox1.Text;
        else
        {
            MessageBox.Show("Invalid number");
            textBox2.Text = "";
        }
    }
