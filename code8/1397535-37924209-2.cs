    public static async Task<UserClass> GetUserInfo()
    {
         Task<UserClass> ui = GetUserData();
         HttpResponseMessage response = await httpClient.SendAsync(request);
         return ui;
    }
    //and then
    var user = await UserClass.GetUserInfo();
    if (user.ReadOnly)
    {
        // code to execute
    }
