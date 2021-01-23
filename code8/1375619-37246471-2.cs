    [TestMethod]
    public void StudentManager_Should_AddNewStudent() {
        //Arrange: setup/initialize the dependencies of the test
        var fName = "Ryan";
        var lName = "Rigil";
        var dob = DateTime.Parse("3006-01-03");
        //using Moq to create mocks/fake of dependencies
        var dbContextMock = new Mock<IDbContext>();
        //Extension method used to create a mock of DbSet<T>
        var dbSetMock = new List<Student>().AsDbSetMock();
        dbContextMock.Setup(x => x.Students).Returns(dbSetMock.Object);
        var factoryMock = new Mock<IFactory>();
        factoryMock
            .Setup(x => x.StudentFac.Create(It.IsAny<Action<Student>>()))
            .Returns<Action<Student>>(a => {
                var s = new Student();
                a(s);
                return s;
            });
        //this is the system/class under test.
        //while this is being created manually, you should look into
        //using DI/IoC container to manage Dependency Injection
        var studentManager = new StudentManager(dbContextMock.Object, factoryMock.Object);
        //Act: here we actually test the method
        var student = studentManager.AddNewStudent(fName, lName, dob);
        //Assert: and check that it executed as expected
        Assert.AreEqual(fName, student.FirstName);
        Assert.AreEqual(lName, student.LastName);
        Assert.AreEqual(dob.ToShortDateString(), student.DoB.ToShortDateString());
    }
