    private void textBox1_TextChanged(object sender, EventArgs e)
    {
         int x = 0;
         if (Int32.TryParse(textBox1.Text, out x)) // you're NOT sure if text is numeric
         {
              var y = 1000000;
              var answer = x * y;
         }
         else 
         {
              // let the user know that numeric values are required
         }
    }
