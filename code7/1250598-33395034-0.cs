        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<User> users = await User.FindAllAsync();
            var current = users.Where(p => p.AuthenticationStatus == UserAuthenticationStatus.LocallyAuthenticated && 
                                        p.Type == UserType.LocalUser).FirstOrDefault();
            // user may have username
            var data = await current.GetPropertyAsync(KnownUserProperties.AccountName);
            string displayName = (string)data;
            //or may be authinticated using hotmail 
            if(String.IsNullOrEmpty(displayName))
            {
                string a = (string)await current.GetPropertyAsync(KnownUserProperties.FirstName);
                string b = (string)await current.GetPropertyAsync(KnownUserProperties.LastName);
                displayName = string.Format("{0} {1}", a, b);
            }
            text1.Text = displayName;
        }
