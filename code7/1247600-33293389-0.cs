    private XiUserInfo Credentials( string username, string password)
    {
        XiEncode rsaParameter = XiContext.GetXiEncode();
        XiUserInfo xiUserInfo = new XiUserInfo( rsaParaeter.Encode, username, password );
        xiUserInfo.Id = rsaParameter.Id;
        return XiUserInfo;
    }
