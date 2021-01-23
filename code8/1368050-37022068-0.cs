    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    System.Security.SecureString ssPwd = new System.Security.SecureString();
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.FileName = "cmd.exe";
    proc.StartInfo.Arguments = "/C echo %username% > c:\\test\\user.txt";
    proc.StartInfo.Domain = "mydomain";
    proc.StartInfo.Verb = "runas";
    proc.StartInfo.UserName = "myadmin";
    string password = "mypassword";
    for (int x = 0; x < password.Length; x++)
    {
        ssPwd.AppendChar(password[x]);
    }
    proc.StartInfo.Password = ssPwd;
    proc.Start();
