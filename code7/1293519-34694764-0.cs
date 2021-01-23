    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        float value;
        if (float.TryParse(textBox1.Text, out value))
        {
            if (value < 2)
            {
                textBox2.Text = "2T"; 
            }
            else if (value < 5) //value==2 can be removed since it is covered in value < 5
            {
                textBox2.Text = "5T";
            }
            else //simply put else here, it is equivalent to what you did
            {
                textBox2.Text = "NG";
            }
        }
        else
        {
            textBox2.Text = ""; 
        }
    }
