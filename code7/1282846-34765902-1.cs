    [Fact]
    public async Task DontCreateAdminUserWhenOtherAdminsPresent()
    {
        await UserManager.CreateAsync(new ApplicationUser { UserName = "some@user.com" }, "IDoComplyWithTheRules2016!");
        ...
    }
