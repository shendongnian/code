    protected void Page_Load(object sender,EventArgs e)
    {
    string username = usernameTextbox.Text.Trim();
    **FormsAuthentication.SetAuthCookie(username, true);**
    callLogin();// this method where in my user authentication logic resides
    }
