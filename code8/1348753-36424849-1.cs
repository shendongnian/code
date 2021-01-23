    private void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton1.Checked) //If checked == true
        {
            textBox1.Text = RadioButton1.Text;
            //example
        }
    }
