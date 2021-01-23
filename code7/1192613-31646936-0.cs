    private void textBox1_TextChanged(object sender, EventArgs e)
    {
              try
              {
         DateTime myDate = DateTime.ParseExact(textBox1.Text, "yyyy-MM-dd H:m:s",System.Globalization.CultureInfo.InvariantCulture);
         TimeChangedHandler(myDate);
              }
             catch (Exception ex)
             {}
    } 
