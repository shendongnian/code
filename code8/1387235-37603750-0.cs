    var token = _cm.Cache.Get<MyToken>(userId); // <-------------------------------+
    if (token != null) return token;            //                                 |
    token = base.Logon(userId, password);       //                                 |
    if (token != null)                          //                                 |
    {                                           //                                 |
        _cm.Cache.Add(userId, token); //<-- A thread needs to execute this before  |
                                      // other threads even execute this  ----------
    }
    return token; 
