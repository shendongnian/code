    [AuthorizationCodeActionFilter]
    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {
    protected static readonly ILogger Logger = ApplicationContext.Logger.ForType<AuthCallbackController>();
    /// <summary>Gets the authorization code flow.</summary>
    protected IAuthorizationCodeFlow Flow { get { return FlowData.Flow; } }
    /// <summary>
    /// Gets the user identifier. Potential logic is to use session variables to retrieve that information.
    /// </summary>
    protected string UserId { get { return FlowData.GetUserId(this); } }
    /// <summary>
    /// The authorization callback which receives an authorization code which contains an error or a code.
    /// If a code is available the method exchange the coed with an access token and redirect back to the original
    /// page which initialized the auth process (using the state parameter).
    /// <para>
    /// The current timeout is set to 10 seconds. You can change the default behavior by setting 
    /// <see cref="System.Web.Mvc.AsyncTimeoutAttribute"/> with a different value on your controller.
    /// </para>
    /// </summary>
    /// <param name="authorizationCode">Authorization code response which contains the code or an error.</param>
    /// <param name="taskCancellationToken">Cancellation token to cancel operation.</param>
    /// <returns>
    /// Redirect action to the state parameter or <see cref="OnTokenError"/> in case of an error.
    /// </returns>
    [AsyncTimeout(60000)]
    public async override Task<ActionResult> IndexAsync(AuthorizationCodeResponseUrl authorizationCode,
       CancellationToken taskCancellationToken)
    {
        if (string.IsNullOrEmpty(authorizationCode.Code))
        {
            var errorResponse = new TokenErrorResponse(authorizationCode);
            Logger.Info("Received an error. The response is: {0}", errorResponse);
            Debug.WriteLine("Received an error. The response is: {0}", errorResponse);
            return OnTokenError(errorResponse);
        }
        Logger.Debug("Received \"{0}\" code", authorizationCode.Code);
        Debug.WriteLine("Received \"{0}\" code", authorizationCode.Code);
        var returnUrl = Request.Url.ToString();
        returnUrl = returnUrl.Substring(0, returnUrl.IndexOf("?"));
        var token = await Flow.ExchangeCodeForTokenAsync(UserId, authorizationCode.Code, returnUrl,
            taskCancellationToken).ConfigureAwait(false);
        // Extract the right state.
        var oauthState = await AuthWebUtility.ExtracRedirectFromState(Flow.DataStore, UserId,
            authorizationCode.State).ConfigureAwait(false);
        return new RedirectResult(oauthState);
    }
    protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
    {
        get { return new AppFlowMetadata(); }
    }
    protected override ActionResult OnTokenError(TokenErrorResponse errorResponse)
    {
        throw new TokenResponseException(errorResponse);
    }
    //public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    //{
    //    protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
    //    {
    //        get { return new AppFlowMetadata(); }
    //    }
    //}
