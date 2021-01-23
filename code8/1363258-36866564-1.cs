    [DataDrivenTestMethod]
    [DataRow("example")]
    [DataRow("example@example.")]
    [DataRow("example@exam ple.com")]
    [DataRow("example@example")]
    public void ValidateEmailAddress(string email) {
        var m = new System.Net.Mail.MailAddress(email);
        Assert.IsNotNull(m);
    }
