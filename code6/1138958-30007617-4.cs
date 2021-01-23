        public string UserToken { get; set; }
        public string UserSecret { get; set; }
        private DropNetClient _Client;
        public DropNetClient Client
        {
            get
            {
                if (_Client == null)
                {
                    _Client = new DropNetClient(AppKey, AppSecret);
                    if (IsAuthenticated)
                    {
                        _Client.UserLogin = new UserLogin
                        {
                            Token = UserToken,
                            Secret = UserSecret
                        };
                    }
                    _Client.UseSandbox = true;
                }
                return _Client;
            }
        }
        public bool IsAuthenticated
        {
            get
            {
                return UserToken != null &&
                    UserSecret != null;
            }
        }
        public void Authenticate(Action<string> success, Action<Exception> failure)
        {
            Client.GetTokenAsync(userLogin =>
            {
                var url = Client.BuildAuthorizeUrl(userLogin);
                if (success != null) success(url);
            }, error =>
            {
                if (failure != null) failure(error);
            });
        }
        public void Authenticated(Action success, Action<Exception> failure)
        {
            Client.GetAccessTokenAsync((accessToken) =>
            {
                UserToken = accessToken.Token;
                UserSecret = accessToken.Secret;
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
                   url => {
                       var proc = Process.Start("iexplore.exe", url);
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
