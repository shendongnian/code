        [Test]
        public void CanGetPerson()
        {
            #region Arrange
            var person = new Person
                {
                    Id = 1,
                    FamilyName = "Rooney",
                    GivenName = "Wayne",
                    MiddleNames = "Mark",
                    DateOfBirth = new DateTime(1985, 10, 24),
                    DateOfDeath = null,
                    PlaceOfBirth = "Liverpool",
                    Height = 1.76m,
                    TwitterId = "@WayneRooney"
                };
            Mapper.CreateMap<Person, PersonDto>(); 
            var mockPersonRepository = new Mock<IPersonRepository>();
            mockPersonRepository.Setup(x => x.GetById(1)).Returns(person);
            var controller = new PersonController(mockPersonRepository.Object);
            controller.Request = new HttpRequestMessage(HttpMethod.Get, "1");
            controller.Configuration = new HttpConfiguration(new HttpRouteCollection());
            #endregion
            #region act
            HttpResponseMessage result = controller.Get(1);
            #endregion
            #region assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            #endregion
        }
        [Test]
        public void CanHandlePersonNotExists()
        {
            #region Arrange
            var mockPersonRepository = new Mock<IPersonRepository>();
            mockPersonRepository.Setup(x => x.GetById(1)).Throws<DataResourceNotFoundException>();
            var controller = new PersonController(mockPersonRepository.Object)
                {
                    Request = new HttpRequestMessage(HttpMethod.Get, "1"),
                    Configuration = new HttpConfiguration(new HttpRouteCollection())
                };
            #endregion
            #region Act
            HttpResponseMessage result = controller.Get(1);
            #endregion
            #region Assert
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            #endregion
        }
        [Test]
        public void CanHandleServerError()
        {
            #region Arrange
            var mockPersonRepository = new Mock<IPersonRepository>();
            mockPersonRepository.Setup(x => x.GetById(1)).Throws<Exception>();
            var controller = new PersonController(mockPersonRepository.Object);
            controller.Request = new HttpRequestMessage(HttpMethod.Get, "1");
            controller.Configuration = new HttpConfiguration(new HttpRouteCollection());
            #endregion
            #region Act
            HttpResponseMessage result = controller.Get(1);
            #endregion
            #region Assert
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
            #endregion
        }
