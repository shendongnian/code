    private void button1_Click(object sender, EventArgs e)
    {
      if(string.isNullOrWhitespace(textbox1.Text)       
         {
            MessageBox.Show("Please enter Values");
            return;
          }
      
       int qty = 0;
       if(!int.TryParse(textBox1.Text, out qty))        
           MessageBox.Show("Please enter a number value");        
       else
          MessageBox.Show("Thank you.");
    }
