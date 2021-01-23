    if (AmateurCheckBox.IsChecked == true)
        {
            int outValue;
            if (String.IsNullOrEmpty(NewNameTextBox.Text))
            {
                Prompt();
            }
            else if (String.IsNullOrEmpty)
            {
                Prompt();
            }
            else if (Int.TryParse(NewNameTextBox.Text, outValue))
            {
                Prompt();
            }
   
            else
            {
                MessageBox.Show("Amateur Competitor Added.");
            }
        }
