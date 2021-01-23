    var credentialLines = File.ReadAllLines(Environment.CurrentDirectory + "\\credentials\\credentials.txt");
    if (credentialLines.Any()){
          UserName_reLogin = credentialLines[0];
          Password_reLogin = credentialLines[1];
    if (LoginUser(Log_API, UserName_reLogin, Password_reLogin)){
        Application.Run(new frmDash ());
    }else{
    Application.Run(new frmlogin());
    }
    }else
    {
    Application.Run(new frmlogin());
    }
