    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        Button btn =(Button)tableLayoutPanel1.Controls.Find("button1", true)[0];
        if (string.IsNullOrEmpty(textBox1.Text))
        {
            btn.Enabled = false;
        }
        else
        {
            btn.Enabled = true;
        }
    }
