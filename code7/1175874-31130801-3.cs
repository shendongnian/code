        private void myTextBox_KeyDown(object sender, KeyEventArgs e)
    {
             if (myTextBox.Text.Length == 2)
              { 
                     if (myTextBox.Text.StartsWith("LP"))
                     {
                        //yourcode
                     }
                     else
                     {
                             myTextBox.Text = string.Empty;
                     }
               }
    }
