    [TestClass]
    public class MyControllerTests
    {
        Mock<ICompanyRepository>() mockCompanyRepository = new Mock<ICompanyRepository>()
        Mock<IPersonRepository>() mockPersonRepository = new Mock<IPersonRepository>()
        MyController sut;
    
        Public MyControllerTests ()
        {
            // Create your "System under test" which is your MyController. Pass in your mock repositories to aid your testing.
            sut = new MyController(mockCompanyRepository.Object, mockPersonRepository.Object)
        }
        
        [TestMethod]
        public void SearchShouldGetCompaniesOnceWhereQueryIsNotEmpty
        {
            //Arrange
            var expectedCompanies = new List<Company>{new Company{"Company1"}, new Company{"Company2"}};
            //Setup mock that will return People list when called:
            mockCompanyRepository.Setup(x => x.Get()).Returns(expectedCompanies);
            mockPersonRepository.Setup(x => x.Get()).Returns(new List<Person>())
     
        //Act
        var result = person.Search("Conway");
     
        //Assert - check the company repository was called once and the result was as expected
        mockCompanyRepository.Verify(x => x.Get(), Times.Once());
    OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
    Assert.Equal("data: [{Name : "Company1"}, {Name : "Company2"}]", conNegResult.Content);
        }
    }
