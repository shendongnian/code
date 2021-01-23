    string sInput = "John;127.0.0.1";
    string[] arrNameAndIP = sInput.Split(';');
    
    bool bIsInputValid = false;
    if(arrNameAndIP.Length == 2)
    {
        Regex rgxNamePattern = new Regex("^[A-za-z]+$");
        bool bIsNameValid = rgxNamePattern.IsMatch(arrNameAndIP[0]);
    
        IPAddress ipAddress;
        bool bIsIPValid = IPAddress.TryParse(arrNameAndIP[1], out ipAddress);
        bIsInputValid = bIsNameValid && bIsIPValid;
    }
