     public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }
            if (!(userName == "test1" && password == "1tset") && !(userName == "test2" && password == "2tset"))
            {
                throw new SecurityTokenException("Unknown Username or Incorrect Password");
            }
        }
