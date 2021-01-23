    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
           try
           {
                AuthenticationResult ar = await App.ClientApplication.AcquireTokenAsync(App.Scopes);
                App.LoggedInUser = ar;
           }
           catch (MsalException ex)
           {
                WelcomeText.Text = ex.Message;
           }
           finally
           {
                await Navigation.PushAsync(new MainTab());
           }
     }
        
