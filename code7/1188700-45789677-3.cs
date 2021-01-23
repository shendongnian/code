    public async void TestSmtpMail()
    {
        var subject = "Your subject";
        var body = "Your mail body";
        var user = await UserManager.FindByEmailAsync("xxx@gmail.com");
        await UserManager.SendEmailAsync(user.Id, subject, body);
    }
