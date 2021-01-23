        public static GoogleCredential GetCredenetial(string serviceAccountCredentialJsonFilePath)
        {
            GoogleCredential credential;
            using (var stream = new FileStream(serviceAccountCredentialJsonFilePath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(GmailService.Scope.GmailReadonly)
                    .CreateWithUser(**impersonateEmail@email.com**);
            }
            return credential;
        }
        public static GmailService GetGmailService(GoogleCredential credential)
        {
            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,                
                ApplicationName = "Automation App",                
            });
        }
       // how to use
       public static void main()
       {
            var credential = GetCredenetial("service.json");
            var gmailService = GetGmailService(credential);
            // you can use gmail service to retrieve emails. 
            var mMailListRequest = gmailService.Users.Messages.List("me");
            mMailListRequest.LabelIds = "INBOX";
            
            var mailListResponse = mMailListRequest.Execute();            
       }
