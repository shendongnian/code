    // sha1 hash the passwords
    string sha1_ws_pwd   = System.Convert.ToBase64String(sha1.ComputeHash(enc.GetBytes(ws_password)));
	string sha1_user_pwd = System.Convert.ToBase64String(sha1.ComputeHash(enc.GetBytes(user_pwd)));
    
    …
    
    string k0 = sha1_ws_pwd + sha1_user_pwd;
	HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(k0));
    …
    string auth = BitConverter.ToString(_auth).Replace("-", string.Empty).ToLower(); 
