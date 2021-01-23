    private void txtExternalLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtExternalLength.Text != string.Empty)
            {
                if (txtExternalLength.Length >= 6000)
                {
                    lblUnderRunBumper.Content = "Under-Run Bumper";
                }
                else 
                {
                    lblUnderRunBumper.Content = ""; //Error here
                }
            }
        }
