    	....
        private bool _authenticateButtonEnabled;
		private DelegateCommand _authenticateCommand;
		public bool AuthenticateButtonEnabled {
			get { return _authenticateButtonEnabled; }
			set
			{
				_authenticateButtonEnabled = value;
				DynamicOnPropertyChanged(); // this is so named to not content with onPropertyChanged defined elsewhere.
				AuthenticateCommand.Update();
			}
		}
        ...
        		
		public DelegateCommand AuthenticateCommand
		{ 
			get {
				if (_authenticateCommand == null)
				{
					_authenticateCommand = new DelegateCommand(Authenticate, AuthenticateEnded);
				}
				return _authenticateCommand;
			}
		}
		private bool AuthenticateEnded(object obj) {
			return _authenticateButtonEnabled;
		}
		private async void Authenticate(object obj)
		{
			AuthenticateButtonEnabled = false;
			ResponseTextBlock = Strings.LoginPage_responseBlock_content_checking;
			i3SoftHttpClient _httpClient = new i3SoftHttpClient();
			i3SoftUser _i3SoftUser;
			AuthenticateCommand.CanExecute(false);
            ....
          // if authentication does not succeed - turn the buttons back on.
            AuthenticateCommand.CanExecute(true);
         }
