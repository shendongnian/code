        [Test]
        public void Confirmation()
        {
            //arrange
            var mock = new Mock<HttpControllerContext>();
            mock.SetupGet(p => p.Request.Content).Returns(theObjectToBeReturned);
            var con = new xController();
            con.ControllerContext = mock.Object;
            //act
            var res = con.Confirmation("hello");
            //assert
            Assert.IsNotNull(res);
        }
