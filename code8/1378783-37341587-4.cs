     private void inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string inputString = ((TextBox)sender).Text;
    
            int valueFromTextBox;
            if (int.TryParse(inputString, out valueFromTextBox))
            {
                //parsing successful 
            }
            else
            {
                //parsing failed. 
            }
        }
