    double input;
    if (double.TryParse(comboBox1.SelectedText, out input)) // can use comboBox1.SelectedValue also if you are binding the values
       {
         if (input == total)
         {
            lblChange.Text = "Amount Correct";
         }
         else if (input > total)
         {
            lblChange.Text = "Total change: " + (input - total);
         }
         else if (input < total)
         {
            lblChange.Text = "Please add more money";
         }
      }
      else
      {
           lblChange.Text = "Please add more money";
      }
