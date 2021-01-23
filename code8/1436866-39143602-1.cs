    private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)  
     {  
        e.Handled = !char.IsDigit(e.KeyChar); 
        if (Int32.Parse(sender.Text) <= 20)
            {
               if (
                    MessageBox.Show("Are you sure you want to go underneath 20?",
                        "... You sure?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) ==
                    MessageBoxResult.Yes)
                    e.Handled = true;
                else
                {
                    num++;
                    textBox.Text = num.ToString();
                }
     } 
