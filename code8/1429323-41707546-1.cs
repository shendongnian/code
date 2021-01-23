        [TestMethod]
        public void CreateEmployee_Returns_HttpStatusCode_Created()
        {
            // Arrange
            var myApiController = new MyApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var employee = new CreateEmployeeModel
            {
                Id = 1
            };
            // Act
            var response = myApiController.CreateEmployee(employee);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
        }
    }
