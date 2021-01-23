    OracleConnection conn;
    using (var pwd = new SecureString()) {
        pwd.Append(...); // Append characters of the password to the string
        ... // Append more characters...
        conn = new OracleConnection(pwd);
    }
    // At this point pwd is erased from memory
