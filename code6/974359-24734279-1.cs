    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string UserName = UserNameFeedField.Text.ToString();
        string Password = PasswordFeedField.Text.ToString();
        string url = "www.something.com/something/some.php?myusername=" + UserName + "&mypassword=" + Password;
    
        using (Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient())
        {
            string contentOfPage = await client.GetStringAsync(new Uri(url));
    
            //Do something with the contentOfPage
        }
    }
