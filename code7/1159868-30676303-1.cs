    private void textbox_TextChanged(object sender, EventArgs e)
    {
       try
       {
          // Convert the text to a Double and assign to slider
          double value;
          if (double.TryParse(textbox.Text, out value))
	      {
		     Slider1.Value = value;
             
             // If the number is valid, display it in Black.
             textBox.ForeColor = Color.Black;
	      }
          else
          {
             // If the number is invalid, display it in Red.
             textBox.ForeColor = Color.Red;
          }
       }
       catch
       {
          // If there is an error, display the text using the system colors.
          textBox.ForeColor = SystemColors.ControlText;
       }
    }
