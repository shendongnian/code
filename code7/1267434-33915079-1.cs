        [Test]
        public void MyClass_Test_SO()
        {
            // arrange
            var context = new Mock<HttpContextBase>();
            var mockIdentity = new Mock<IIdentity>();
            context.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);
            mockIdentity.Setup(u => u.Name).Returns("test_userName");
            var sut = new MyClass(context.Object);
            // act
            sut.Process();
            // assert
            // ... whatever
        }
