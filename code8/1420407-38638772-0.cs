    var processInfo = new ProcessStartInfo
    {
        FileName = System.Reflection.Assembly.GetExecutingAssembly().Location,
        UserName = txtWinLoginUsername.Text,
        Password = txtWinLoginPassword.SecurePassword,
        Domain = this.domain,
        UseShellExecute = false, //kein Plan
        LoadUserProfile = true
        //^^^^^^^^^^^^^^^^^^^^
        //Add this line
    };
