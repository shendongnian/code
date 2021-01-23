        [Test]
        public void Confirmation()
        {
            //arrange
            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.Request.Content).Returns(theObjectToBeReturned);
            var con = new xController();
            con.ControllerContext = mock.Object;
            //act
            var res = con.Confirmation("hello");
            //assert
            Assert.IsNotNull(res);
        }
