        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Disable login button to avoid multiple login attempts
                loginButton.IsEnabled = false;
                m_mainform.AttemptLogin(UNtextBox.Text, PWpasswordBox.Password, otherID1, otherID2, this);
            }
            catch (Exception Ex)
            {
                loginButton.IsEnabled = true;
                //Login Error - Report error
            }
        }
