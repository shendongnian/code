    //e.g.
    Dictionary<int, string> data = new Dictionary<int, string>
    { 
       {1, "value 1"},
       {2, "value 2"},
       {3, "value 3"}
    };
    
    
    //With your POCO can create a Dictionary as below
    Dictionary<int, User> data = new Dictionary<int, User>
    { 
       {1, new User{ userName = "username1", password = "password1", savingsAcct  = 1,checkAcct = 1 }},
       {2, new User{ userName = "username2", password = "password2", savingsAcct  = 1,checkAcct = 2 }},
       {3, new User{ userName = "username3", password = "password3", savingsAcct  = 1,checkAcct = 3}}
    };
