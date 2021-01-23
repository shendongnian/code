    [TestMethod]
    public async Task TestPostFoo() {
        //Arrange
        bool saved = false;
        var model = new Foo {
            Name = "New Foo",
            QuxId = 99,
            Qux = null,
            BarId = 66,
            Bar = null
        };
        var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.SaveChangesAsync())
            .Returns(() => Task.FromResult(0))
            .Callback(() => {
                model.Id = 1;
                saved = true;
            });
        mockUnitOfWork
            .Setup(x => x.LoadRelatedEntity<Foo, Qux>(It.IsAny<Foo>(), It.IsAny<Expression<Func<Foo, Qux>>>()))
            .Callback(() => model.Qux = new Qux());
        mockUnitOfWork
            .Setup(x => x.LoadRelatedEntity<Foo, Bar>(It.IsAny<Foo>(), It.IsAny<Expression<Func<Foo, Bar>>>()))
            .Callback(() => model.Bar = new Bar());
        var controller = new TestsFooApiController(mockUnitOfWork.Object);
        controller.Request = new HttpRequestMessage { };
        controller.Configuration = new HttpConfiguration();
        //Act
        var result = await controller.PostFoo(model) as CreatedAtRouteNegotiatedContentResult<Foo>;
        //Assert
        result.Should().NotBeNull();
        result.Content.Should().NotBeNull();
        result.Content.Id.Should().BeGreaterThan(0);
        result.Content.Qux.Should().NotBeNull();
        result.Content.Bar.Should().NotBeNull();
        saved.Should().BeTrue();
    }
