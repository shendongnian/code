    <script runat="server">
    	private Model.User _user;
    	protected void Page_Load(object sender, EventArgs e) {
            // _user is stored in the session, the *very same* object
    		_user = HttpContext.Current.Session[Model.Common.UserSessionNameValue] as Model.User;
    		if (_user == null) {
    			_user = new Model.User();
    		}
            
    		var submit = Request.Form["Submit"] ?? String.Empty;
    		if (!String.IsNullOrWhiteSpace(submit)) {
    			var strUserId = Request.Form["UserId"] ?? String.Empty;
    			var userName = Request.Form["UserName"] ?? String.Empty;
    			var email = Request.Form["Email"] ?? String.Empty;
    			Int32 userId;
    			Int32.TryParse(strUserId, out userId);
                
                // So, if you update _user's fields. What is stored in the session will be changed as well.
    			_user.UserId = userId;
    			_user.UserName = userName;
    			_user.Email = email;
                
                // Regardless, if you "saved" back or not
    			if (submit.Equals("Submit with Save")) {
                    // because the left-hand side and the right-hand side are the same object
    				HttpContext.Current.Session[Model.Common.UserSessionNameValue] = _user;
    			}
    			Response.Redirect(Request.RawUrl);
    		}
    	}
    </script>
