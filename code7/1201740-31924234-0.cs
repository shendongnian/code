    private void login_action(object sender, RoutedEventArgs e)
    {
    	string _username = txtUser.Text;
    	string _password = txtPass.Password;
    	kollserviceClient client = new kollserviceClient(); 
    	client.validUserCredentialAsync(_username, _password);
    	client.validUserCredentialCompleted += Client_validUserCredentialCompleted;
    	client.isStudentUserAsync(_username);
    	client.isStudentUserCompleted += Client_isStudentUserCompleted;
    
    }
    private bool? isStudent = null;
    private bool? isAuthenticated = null;
    
    private void Client_isStudentUserCompleted(object sender, isStudentUserCompletedEventArgs e)
    {
    	isStudent = e.Result;
    	EvaluateAndNavigate();
    	
    }
    
    private void Client_validUserCredentialCompleted(object sender, validUserCredentialCompletedEventArgs e)
    {
    	isAuthenticated = e.Result;
    	if (isAuthenticated)
    	{
    		IsolatedStorageSettings.ApplicationSettings["lgusername"] = txtUser.Text;
    	}
    	EvaluateAndNavigate();
    }
    
    private void EvaluateAndNavigate()
    {
    	if(isStudent.HasValue && isAuthenticated.HasValue) //both calls have returned
    	{
    		if(isStudent && isAuthenticated)
    		{
    			NavigationService.Navigate(new Uri("/Home.xaml", UriKind.RelativeOrAbsolute));
    		}
    		else
    		{
    			MessageBox.Show(string.Format("{0}Unable to Login", isStudent ? "" : "User is Not a Student. " ), "Error", MessageBoxButton.OK);
    		}
    	}
    }
