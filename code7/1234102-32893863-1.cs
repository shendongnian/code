    private List<Users> GetUsersList()
    {
        try
        {
            List<Users> list = new List<Users>();
            IEnumerable<XboxUser> users = _xbc.Users;
            foreach (XboxUser user in users)
            {
                Users xbuser = new Users()
                {
                    UserID = user.UserId,
                    EmailAddress = user.EmailAddress,
                    Gamertag = user.Gamertag,
                    Xuid = user.Xuid,
                    SignedIn = user.IsSignedIn.ToString(),
                    AutoSignin = user.AutoSignIn.ToString(),
                    Gamerpic = GetImageFromUrl(Gamertag.Text)
                };
                list.Add(xbuser);
            }
            return list;
        }
        catch (Exception ex)
        {
        }
        return null;
    }
