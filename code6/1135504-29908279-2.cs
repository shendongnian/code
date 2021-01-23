    Thread t = new Thread (delegate()
    {
        try
        {
            session = new AuthenticatedSession<User>(new User(username), Cryptography.GetMd5(password));
            Success();
        }
        catch (InvalidAuthenticationException)
        {
            Fail();
        }     
    });
    t.Start();
