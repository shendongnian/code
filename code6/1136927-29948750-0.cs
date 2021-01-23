    private async void buildLoginUser(string strUserName, string strPassword)
    {
        if (strUserName == null || strPassword == null) {
            strResult = "Please Enter User Name and Password.";
            DisplayAlert("Alert",strResult,"OK"); 
        } else {
            //IF USERNAME AND PASSWORD RECEIVED VALIDATE AGAINST DB
            //cl.ValidateUserAsync (strUserName, strPassword);
            //strResult = strUserRole;
            BuildClientService bcs = new BuildClientService ();
            //AuthenticateUser au = new AuthenticateUser ();
            TDMSClient cl = new TDMSClient ();
            cl = bcs.InitializeServiceClient();
            await cl.ValidateUserAsync(strUserName, strPassword);
            //au.AuthenticateUserLogin (strUserName, strPassword, cl);
            //DisplayAlert("New User", lu.FullName, "OK");
            if (string.IsNullOrEmpty(lu.FullName)) {
                DisplayAlert ("Alert", "NULL", "OK");
            } else {
                DisplayAlert ("Alert", lu.FullName, "OK");
            }
        }
    }
