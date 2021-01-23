    [TestMethod]
    public void Should_Use_Email_Address_Attribute_To_Validate_Email() {
        var emailChecker = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
        string email = "some@email.com";
        bool isValid = emailChecker.IsValid(email);
        Assert.IsTrue(isValid);
    }
    [TestMethod]
    public void Should_Use_Email_Address_Attribute_To_Invalidate_Email() {
        var emailChecker = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
        string email = "some@emai l.com";
        bool isValid = emailChecker.IsValid(email);
        Assert.IsFalse(isValid);
    }
