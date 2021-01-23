    private void textBox3_TextChanged(object sender, EventArgs e)
    {
    	if (textBox3.Focused == true)
    	{
    		if (string.IsNullOrEmpty(textBox3.Text))
    		{
    			textBox1.Text = "";
    			textBox2.Text = "";
    		}
    		else
    		{
    			int decValue = int.Parse(textBox3.Text, System.Globalization.NumberStyles.HexNumber);
    			string decimalnumber = Convert.ToString(decValue, 10);
    			string binary = Convert.ToString(decValue, 2);
    			textBox1.Text = decimalnumber;
    			textBox2.Text = binary;
    		}
    	}
    }
