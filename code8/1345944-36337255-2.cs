        private void txtExternalLength_TextChanged(object sender, TextChangedEventArgs e)
                {
                    if (txtExternalLength.Text != string.Empty)
                    {
                        int count = 0;
                        
                        bool result = Int32.TryParse(txtExternalLength.Text, out count);
                        // Int32.TryParse(input, out output) will try to Convert the text (string) of your Textbox to an Int32. If it is successfull the result will be true, else it will be false.
                        if (result && count >= 6000)
                        {
                            lblUnderRunBumper.Content = "Under-Run Bumper";
                        }
                        else 
                        {
                            lblUnderRunBumper.Content = ""; //Error here
                        }
                    }
                }
