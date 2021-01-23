            private async void DisplayMessage()
            {
                try
                {                    
                    WelcomeText.Text = $"Welcome {App.LoggedInUser.User.Name}";
                }
                catch (MsalException ex)
                {
                    WelcomeText.Text = ex.Message;
                }
                finally
                {
                    WelcomeTextTwo.Text = "BlaBlaBlab";
                }
            }
