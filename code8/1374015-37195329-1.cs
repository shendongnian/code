        [TestMethod]
        public void Post_Returns422()
        {
            var controller = new MyTestController();
            // Act
            IHttpActionResult actionResult = controller.Post(It.IsAny<object>());
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(StatusCodeResult));
            Assert.AreEqual((int)((StatusCodeResult)actionResult).StatusCode,422);
        }
