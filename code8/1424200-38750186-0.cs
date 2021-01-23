    public bool IsSwedishSsn(string identity)
    {
        identity = identity.Replace("-", "");
        
        if (identity.Length == 12)
            identity = identity.Substring(2, 10);
        
        return bool socialSecurityNumber = identity.Substring(2, 1) == "0" || identity.Substring(2, 1) == "1"; 
    } 
