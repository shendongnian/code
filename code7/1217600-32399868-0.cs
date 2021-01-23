    if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox1.Text))                    
      {
         MessageBox.Show("Fill out textBox1 and textBox2"); 
         return;               
      }
    // two filled out or two empty
    if (string.IsNullOrEmpty(textBox3.Text) != string.IsNullOrEmpty(textBox4.Text)) 
    {
         MessageBox.Show("Fill out or empty textBox3 and textBox4");
         return;                
    }
    // two filled out or two empty
    if (string.IsNullOrEmpty(textBox5.Text) != string.IsNullOrEmpty(textBox6.Text)) 
    {
         MessageBox.Show("Fill out or empty textBox5 and textBox6"); 
         return;               
    }
    // if all empty error
        if (string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox5.Text)) 
        {
             MessageBox.Show("Fill out 3,4 or 5,6 or 3,4,5,6");                
        }
