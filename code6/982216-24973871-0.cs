        [Test]
        public void Foo_WhenCalled_CallsDb()
        {
            //Arrange
            var fakeDbSet = new Mock<DbSet<Course>>();
            fakeDbSet.Setup(dbs => dbs.Find(It.IsAny<object>())).Returns(new Course { CourseID = 125 });
            var fakeContext = new Mock<SchoolEntities>();
            fakeContext.Setup(c => c.Courses).Returns(fakeDbSet.Object);
            
            var foo = new Foo(fakeContext.Object);
            //Act
            string result = foo.MyMethod();
            //Assert
            Assert.AreEqual("125", result);
        }
