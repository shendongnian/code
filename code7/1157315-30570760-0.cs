    /// <summary>
    /// replace email domain
    /// </summary>
    /// <param name="email"> email </param>
    /// <param name="newDomain"> new domain </param>
    /// <returns></returns>
    private string ReplaceMailDomain(string email, string newDomain)
    {
        if (email == null) throw new ArgumentNullException("email");
    
        int pos = email.IndexOf('@');
        if (pos < 0)
        {
            throw new ArgumentException("Invalid email", "email");
        }
        else
        {
            return email.Substring(0, pos + 1) + newDomain;
        }
    }
