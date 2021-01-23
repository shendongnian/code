    private async Task getEmails()
            {
                try
                {
                    UserCredential credential;
                    using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                    {
                        credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.Load(stream).Secrets,
                            // This OAuth 2.0 access scope allows for read-only access to the authenticated 
                            // user's account, but not other types of account access.
                            new[] { GmailService.Scope.GmailReadonly, GmailService.Scope.MailGoogleCom, GmailService.Scope.GmailModify },
                            "NAME OF ACCOUNT NOT EMAIL ADDRESS",
                            CancellationToken.None,
                            new FileDataStore(this.GetType().ToString())
                        );
                    }
    
                    var gmailService = new GmailService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = this.GetType().ToString()
                    });
    
                    var emailListRequest = gmailService.Users.Messages.List("EMAILADDRESSHERE");
                    emailListRequest.LabelIds = "INBOX";
                    emailListRequest.IncludeSpamTrash = false;
                    //emailListRequest.Q = "is:unread"; //this was added because I only wanted undread email's...
                   
                    //get our emails
                    var emailListResponse = await emailListRequest.ExecuteAsync();
    
                    if (emailListResponse != null && emailListResponse.Messages != null)
                    {
                        //loop through each email and get what fields you want...
                        foreach (var email in emailListResponse.Messages)
                        {
    
                            var emailInfoRequest = gmailService.Users.Messages.Get("EMAIL ADDRESS HERE", email.Id);
                            //make another request for that email id...
                            var emailInfoResponse = await emailInfoRequest.ExecuteAsync();
    
                            if (emailInfoResponse != null)
                            {
                                String from = "";
                                String date = "";
                                String subject = "";
                                String body = "";
                                //loop through the headers and get the fields we need...
                                foreach (var mParts in emailInfoResponse.Payload.Headers)
                                {
                                    if (mParts.Name == "Date")
                                    {
                                        date = mParts.Value; 
                                    }else if(mParts.Name == "From" ){
                                        from = mParts.Value;
                                    }else if (mParts.Name == "Subject"){
                                        subject = mParts.Value;
                                    }
    
                                    if (date != "" && from != "")
                                    {
                                        if (emailInfoResponse.Payload.Parts == null && emailInfoResponse.Payload.Body != null)
                                        {
                                            body = emailInfoResponse.Payload.Body.Data;
                                        }
                                        else
                                        {
                                            body = getNestedParts(emailInfoResponse.Payload.Parts, "");
                                        }
                                        //need to replace some characters as the data for the email's body is base64
                                        String codedBody = body.Replace("-", "+");
                                        codedBody = codedBody.Replace("_", "/");
                                        byte[] data = Convert.FromBase64String(codedBody);
                                        body = Encoding.UTF8.GetString(data);
                                       
                                                                     
                                        //now you have the data you want....
                                   
                                    }
    
                                }
                            }
                            
                        }
                    }
                   
                }catch (Exception){
                    MessageBox.Show("Failed to get messages!", "Failed Messages!", MessageBoxButtons.OK); 
                }
            }
