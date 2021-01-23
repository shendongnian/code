        public void Authenticate(Action<Uri> success, Action<Exception> failure)
        {
            _client.GetTokenAsync(userLogin =>
            {
                var url = _client.BuildAuthorizeUrl(userLogin);
                if (success != null) success(new Uri(url, UriKind.RelativeOrAbsolute));
            }, error =>
            {
                if (failure != null) failure(error);
            });
        }
        public void Authenticated(Action success, Action<Exception> failure)
        {
            _client.GetAccessTokenAsync((accessToken) =>
            {
                // Save accessToken.Token & accessToken.Secret;
                if (success != null) success();
            },
            (error) =>
            {
                if (failure != null) failure(error);
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Authenticate(
                   uri => {
                       var url = uri.ToString();
                       var proc = Process.Start(url);
                       proc.WaitForExit(); 
                        Authenticated(
                            () =>
                            {
                                MessageBox.Show("Authenticated");
                            },
                            exc => ShowException(exc));
                  
                   },
                   ex => ShowException(ex));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Client.AccountInfoAsync((a) =>
            {
                MessageBox.Show(a.display_name);
            },
            ex => ShowException(ex));
        }
        private void ShowException(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
