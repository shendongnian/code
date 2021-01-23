	// unit test
	[TestMethod]
	public void BaseRepository_GetAll() {
		// arrange
		// this is the mocked data contained in your mocked DbContext
		var patients = new List<Patient>(){
		  new Patient(){/*set properties for mocked patient 1*/},
		  new Patient(){/*set properties for mocked patient 2*/},
		  new Patient(){/*set properties for mocked patient 3*/},
		  new Patient(){/*set properties for mocked patient 4*/},
		  /*and more if needed*/
		};
		// Create a fake/Mocked DbContext
		var mockedContext = NSubstitute.Substitute.For<DbContext>();
		// call to extension method which mocks the DbSet and adds it to the DbContext
		mockedContext.AddToDbSet(patients);
		
		// create your repository that you want to test and pass in the fake DbContext
		var repo = new BaseRepository<Patient>(mockedContext);
		
		// act
		var results = repo.GetAll();
		// assert
		Assert.AreEqual(results.Count(), patients.Count);
	}
