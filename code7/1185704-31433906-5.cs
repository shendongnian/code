    [Test]
    public void ListOfPeople_peopleExist_returnsList()
    {
        // Arrange : Generate fake data
        var people = new List<DB.Person>
        {    
            new DB.Person
            {
                PersonId = 123,
                PersonName = "Bob",
                PrimaryLanguage = "French",
                WorkTypeId = 987,
                PeopleGroups = new []
                {
                    new DB.PeopleGroup
                    {
                        AddressId = 123,
                        PersonGroupJobId = 999,
                        PeopleId = 123, // Match the parent ID
                        ProjectPartyId = 3
                    }
                }
            }
        };
        // Your _unitOfWork and _repository mocks seem to be class private fields
        var _unitOfWork = new Mock<IUnitOfWork>();
        _unitOfWork
            .Setup(mock => mock.GetRepository<DB.Person>().GetAll())
            .Returns(people.AsQueryable());
        var _repository = new MyRepo(_unitOfWork.Object);
        // Act
        var result = _repository.ListOfPeople(123, 999);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count(r => r.Name == "Bob" 
                                             && r.Id == 123 
                                             && r.PeopleGroups.First().Id == 3));
      //... etc - ensure all the fields are mapped 
        _unitOfWork.Verify(mock => mock.Commit(), Times.Never());
        _unitOfWork.Verify(mock => mock.GetRepository<DB.Person>().GetAll(), 
                           Times.Once());
    }
