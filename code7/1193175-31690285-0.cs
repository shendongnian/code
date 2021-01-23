    protected void Page_Load(object sender, EventArgs e)
    {         
        if(!IsPostBack)
        {
            #region Initilization
            //Check for Null Session Variable
            if (Session["LoggedInUser"]) != null){
                string myName = Session["LoggedInUser"].ToString();
                ds = UC.GetMemberID(myName);
                //Check if the Table is empty
                if(ds.Tables.Contains("Members") && ds.Tables["Members"].Rows.Count > 0){
                    Session["CurrentUserID"] = Convert.ToInt32(ds.Tables["Members"].Rows[0]["MemberID"].ToString());
                    // Current Groups For User grid
                    rgCurrentGroups.DataSource = UC.GetMemberGroups(Convert.ToInt32(Session["CurrentUserID"]));
                    rgCurrentGroups.DataBind();
                    // Add Contacts to Group grid
                    rgAddContactsToGroups.DataSource = UC.GetMemberContactsForGrid(Convert.ToInt32(Session["CurrentUserID"]));
                    rgAddContactsToGroups.DataBind();
                    // Groups To Select
                    ddGroupToSelect.DataSource = UC.GetMemberGroups(Convert.ToInt32(Session["CurrentUserID"]));
                    ddGroupToSelect.DataTextField = "MemberGroupName";
                    ddGroupToSelect.DataValueField = "MemberGroupsID";
                    ddGroupToSelect.DataBind();
                    #endregion
                    #region Import Contacts
                    //i.e. outlook
                    if (Request.QueryString["code"] != null && Request.QueryString["state"] != null)
                    {
                        iOutlook io = new iOutlook();
                        WebServerClient consumer = new WebServerClient(io.server, io.clientID, io.clientSecret);
                        IAuthorizationState grantedAccess = consumer.ProcessUserAuthorization(null);
                        string accessToken = grantedAccess.AccessToken;
                        string returnStr = new System.Net.WebClient().DownloadString("https://apis.live.net/v5.0/me/contacts?access_token=" + accessToken);
                        dynamic json = System.Web.Helpers.Json.Decode(returnStr);
                        foreach (var item in json.data)
                        {
                            Response.Write(item.name + "</br>" + item.emails.preferred + "</br>------------------------------</br>");
                        }
                    }
                    //Yahoo
                    string oauth_token = Request["oauth_token"];
                    string oauth_verifier = Request["oauth_verifier"];
                    //To Close open window opened by "Login with yahoo" button
                    if (!string.IsNullOrEmpty(oauth_verifier) && oauth_verifier != "")
                    {                    
                        OauthToken = oauth_token;
                        OauthVerifier = oauth_verifier;
                        Page.ClientScript.RegisterStartupScript(GetType(), "refresh", "window.opener.location = 'home.aspx'; self.close();", true);
                    }
                    //This will load once we automatically close the login popup window by above if statement
                    else if (!string.IsNullOrEmpty(OauthVerifier))
                    {                 
                        if (string.IsNullOrEmpty(OauthYahooGuid))
                            GetAccessToken(OauthToken, OauthVerifier);
                        //RefreshToken();
                        RetriveContacts();
                        //need to set as empty because we don't need to repeat RetriveContacts() condition
                        OauthVerifier = string.Empty;
                    }
                    #endregion
                }
            }
        }
    }
