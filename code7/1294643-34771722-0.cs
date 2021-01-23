    // using System.Security.Cryptography;
    
    var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
        @"/user data that only a program run by this user can read.dat";
    Console.WriteLine(path);
    var entropy = Encoding.UTF8.GetBytes("See http://security.stackexchange.com/a/58121");
    
    
    var data = Encoding.UTF8.GetBytes(
        @"Data to be stored in a way that only programs that run under 
        this account can decrypt but nobody's eyes can understand. But 
        if an admin forces a password change, it's irretrievable 
        (see http://stackoverflow.com/a/4755929/2226988).");
    File.WriteAllBytes(path, ProtectedData.Protect(
        data, 
        entropy, 
        DataProtectionScope.CurrentUser));
    
    
    var readBack = ProtectedData.Unprotect(
        File.ReadAllBytes(path), 
        entropy, 
        DataProtectionScope.CurrentUser);
    Console.WriteLine(Encoding.UTF8.GetString(readBack));
