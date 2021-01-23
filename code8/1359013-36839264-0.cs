    public void TestGetClaimsPrincipal()
    {
        //Arrange 
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, "Name"));
        claims.Add(new Claim(ClaimTypes.Email, "name@gmail.com"));
        var myIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        var myPrincipal = new ClaimsPrincipal(myIdentity);
        var target = new UserClaimsPrincipalFactory();
        Isolate.NonPublic.WhenCalled(target, "GetClaimsPrincipal").WillReturn(myPrincipal);
    
        //Act
        var result = Isolate.Invoke.Method(target, "GetClaimsPrincipal") as ClaimsPrincipal;
    
        //Assert
        Assert.AreEqual("Name", result.Identity.Name);
    }
