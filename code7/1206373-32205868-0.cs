    private readonly ILogManager _logManager; 
    private readonly IStorageService _storageService; 
    private UserCredential _credential; 
    private Oauth2Service _authService; 
    private Userinfoplus _userinfoplus; 
    
    /// <summary> 
    /// Initializes a new instance of the <see cref="GoogleService" /> class. 
    /// </summary> 
    /// <param name="logManager">The log manager.</param> 
    /// <param name="storageService">The storage service.</param> 
    public GoogleService(ILogManager logManager, IStorageService storageService) 
    { 
    	_logManager = logManager; 
    	_storageService = storageService; 
    }
     /// <summary> 
    /// The login async. 
    /// </summary> 
    /// <returns> 
    /// The <see cref="Task"/> object. 
    /// </returns> 
    public async Task<Session> LoginAsync() 
    { 
    Exception exception = null; 
    try 
    { 
    	// Oauth2Service.Scope.UserinfoEmail 
    	_credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets 
    	{ 
    		ClientId = Constants.GoogleClientId, 
    		ClientSecret = Constants.GoogleClientSecret 
    	}, new[] { Oauth2Service.Scope.UserinfoProfile }, "user", CancellationToken.None); 
    	 
    	var session = new Session 
    	{ 
    		AccessToken = _credential.Token.AccessToken, 
    		Provider = Constants.GoogleProvider, 
    		ExpireDate = 
    			_credential.Token.ExpiresInSeconds != null 
    				? new DateTime(_credential.Token.ExpiresInSeconds.Value) 
    				: DateTime.Now.AddYears(1), 
    		Id = string.Empty 
    	}; 
    
    	return session; 
    } 
    catch (TaskCanceledException taskCanceledException) 
    { 
    	throw new InvalidOperationException("Login canceled.", taskCanceledException); 
    } 
    catch (Exception ex) 
    { 
    	exception = ex; 
    } 
    await _logManager.LogAsync(exception); 
    return null; 
    }
    /// <summary> 
    /// Gets the user information. 
    /// </summary> 
    /// <returns> 
    /// The user info. 
    /// </returns> 
    public async Task<Userinfoplus> GetUserInfo() 
    { 
    	_authService = new Oauth2Service(new BaseClientService.Initializer() 
    	{ 
    		HttpClientInitializer = _credential, 
    		ApplicationName = AppResources.ApplicationTitle, 
    	}); 
    	_userinfoplus = await _authService.Userinfo.V2.Me.Get().ExecuteAsync(); 
    
    	return _userinfoplus; 
    } 
