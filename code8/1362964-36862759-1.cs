    // Construct the data to be returned by the student set mock.
    // Note, you don't want this to be in the order that you're expecting
    // otherwise, how do you know if it's been sorted...
    var studentData = new List<Student> {
        new Student {
                         Id = "123",
                         EnrollTime = "02/22/16 14:06:56 PM",
                         Course = 1
                     },
         new Student {
                         Id = "456",
                         EnrollTime = "03/30/16 12:50:38 PM",
                         Course = 3
                     }
    }.AsQueryable();
    // Setup a mock of the student set, which returns the canned data
    // prepared above
    var dbSetMock = new Mock<IDbSet<Student>>();
    dbSetMock.Setup(m => m.Provider).Returns(studentData.Provider);
    dbSetMock.Setup(m => m.Expression).Returns(studentData.Expression);
    dbSetMock.Setup(m => m.ElementType).Returns(studentData.ElementType);
    dbSetMock.Setup(m => m.GetEnumerator()).Returns(studentData.GetEnumerator());
    // Create a mock of the catalog context that returns
    // the mocked set prepared above
    var contextMock = new Mock<StudentCatalogContext>();
    contextMock.Setup(x=>x.Student).Returns(dbSetMock.Object);
    // Create the system under test, injecting the mock context
    var repo = new StudentRepository(contextMock.Object);
    // Call the method that we're actually testing
    var fetchedData = repo.GetAllStudents();
    // Validate that the information returned is what we're expecting
    Assert.AreEqual("02/22/16 14:06:56 PM", fetchedData[0].EnrollTime);
