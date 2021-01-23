    //get the username
    string UserName = txtUserName.Text;
 
    //create the MD5CryptoServiceProvider object we will use to encrypt the password
    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
    //create an array of bytes we will use to store the encrypted password
    Byte[] hashedBytes;
    //Create a UTF8Encoding object we will use to convert our password string to a byte array
    UTF8Encoding encoder = new UTF8Encoding();
 
    //encrypt the password and store it in the hashedBytes byte array
    hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(txtPassword.Text));
