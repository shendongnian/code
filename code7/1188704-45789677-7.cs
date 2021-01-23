    public async Task<IHttpActionResult> TestSmtpMail()
    {
        var subject = "Your subject";
        var body = "Your email body it can be html also";
        var user = await UserManager.FindByEmailAsync("xxx@gmail.com");
        await UserManager.SendEmailAsync(user.Id, subject, body);
        return Ok();
    }
