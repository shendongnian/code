    [Test]
    public void Should_GetUserId_From_Identity() {
        //Arrange
        var username = "test@test.com";
        var identity = new GenericIdentity(username, "");
        var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, username);
        identity.AddClaim(nameIdentifierClaim);
                        
        var mockPrincipal = new Mock<IPrincipal>();
        mockPrincipal.Setup(x => x.Identity).Returns(identity);
        mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);
        Kernel.Rebind<IPrincipal>().ToConstant(mockPrincipal.Object);
        //Act
        var principal = Kernel.Get<IPrincipal>();
        //Asserts        
        Assert.AreEqual(username, principal.Identity.GetUserId());
        Assert.IsTrue(principal.Identity.IsAuthenticated);
    }
