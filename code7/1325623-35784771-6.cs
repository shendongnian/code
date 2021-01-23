    [Test]
    public void MaxRole_SuperAdmin()
    {
        var userStoreStub = NSubstitute.Substitute.For<IUserStore<ApplicationUser>>();
        var sut = new ApplicationUserManager(userStoreStub);
        //TODO set up method substitutions on userStoreStub - see NSubstitute documentation
        var maxRole = sut.GetMaxRole(SuperAdminUserId);
        Assert.AreEqual(maxRole, "Super Admin");
    }
