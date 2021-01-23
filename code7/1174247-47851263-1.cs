        public void MockObjectResultReturn_OfString_Test()
        {
            // arrange
            const string shouldBe = "Hello World!";
            var sut = new Mock<ObjectResult<string>>();
            // act
            sut.SetupReturn<string>(shouldBe);
            //assert
            Assert.IsNotNull(sut);
            Assert.IsNotNull(sut.Object);
            Assert.AreEqual(shouldBe, sut.Object?.FirstOrDefault());
        }
