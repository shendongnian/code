    private void textBox1_TextChanged(object sender, EventArgs e)
    {
         DateTime myDate = default(DateTime);
         if(!DateTime.TryParseExact(textBox1.Text, "yyyy-MM-dd H:m:s",
         System.Globalization.CultureInfo.InvariantCulture, out myDate))
           DateTime.TryParseExact(textBox1.Text, "yyyy-MM-dd HH:mm:ss",
             System.Globalization.CultureInfo.InvariantCulture, out myDate)     
         if(myDate == default(DateTime)) return; // or
          // throw new ArgumentException("your text here");
         TimeChangedHandler(myDate);
    } 
