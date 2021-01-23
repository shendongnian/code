    [Route("login")]
    [System.Web.Http.AcceptVerbs("GET")]
    [System.Web.Http.HttpGet]
    public NumbersModelByte Login()
    {
        byte[] mSessionID = new Session().getmSessionID();
        return new NumbersModelByte
        {
            Numbers = mSessionID
        };
    }
