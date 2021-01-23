    void button1_Click(object sender, EventArgs e)
    {
    	try
    	{
    		guess = int.Parse(textBox_Guess.Text);
    		
    	}
    	catch (Exception)
    	{
    		label_Reveal.ForeColor = System.Drawing.Color.Red;
    		label_Reveal.Text = "Your input is invalid!";
    		label_Reveal.Show();
    	}
    }
