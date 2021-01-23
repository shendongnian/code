    private void SomeMethod()
    {
        var userIdStr =GetUserProperty("UserId", "0");
        Debug.Assert(userIdStr.All(char.IsDigit));
        var userId = Convert.ToInt32(userIdStr);
        // Do something with userId..
    }
