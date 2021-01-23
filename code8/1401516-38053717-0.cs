    var process = new Process();
    var securePassword = new SecureString();
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.FileName = "path to you application";
    process.StartInfo.Arguments = "/runAsOther";
    process.StartInfo.Domain = "domainname";
    process.StartInfo.UserName = "username";
    var password = "test";
    for (int x = 0; x < password.Length; x++)
        securePassword.AppendChar(password[x]);
    process.StartInfo.Password = securePassword;
    process.Start();
