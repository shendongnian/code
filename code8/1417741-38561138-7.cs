    public void Given_User_Index_Should_Return_ViewResult_With_Model() {
        //Arrange 
        var username = "FakeUserName";
        var identity = new GenericIdentity(username, "");
    
        var mockPrincipal = new Mock<IPrincipal>();
        mockPrincipal.Setup(x => x.Identity).Returns(identity);
        mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);
    
        var mockHttpContext = new Mock<HttpContext>();
        mockHttpContext.Setup(m => m.User).Returns(mockPrincipal.Object);
        var controller = new MyController() {
            ControllerContext = new ControllerContext {
                HttpContext = mockHttpContext.Object
            }
        };
    
        //Act
        var viewResult = controller.Index() as ViewResult;
    
        //Assert
        Assert.IsNotNull(viewResult);
        Assert.IsNotNull(viewResult.Model);
    }
