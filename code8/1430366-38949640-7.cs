    [Route("Login")]
    [HttpPost]   
    public byte[] Login()
    {
        byte[] mSessionID = new Session().getmSessionID();
        return new NumbersModelInt
        {
            Numbers = mSessionID.Select(b => (int) b).ToArray()
        };
    }
