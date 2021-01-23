    <script runat="server">
    	private Model.User _user;
    	protected void Page_Load(object sender, EventArgs e) {
    		if (!string.IsNullOrWhiteSpace(Request.Form["Submit"])) {
                var strUserId = Request.Form["UserId"] ?? string.Empty;
                var userName = Request.Form["UserName"] ?? string.Empty;
                var email = Request.Form["Email"] ?? string.Empty;
    			Int32 userId;
    			Int32.TryParse(strUserId, out userId);
                
                _user = new Model.User()
                {
                    UserId = userId;
                    UserName = userName;
                    Email = email;
                }
                
    			if (Request.Form["Submit"] == "Submit with Save") {
    				HttpContext.Current.Session[Model.Common.UserSessionNameValue] = _user;
    			}
                
    			Response.Redirect(Request.RawUrl);
    		}
    	}
    </script>
