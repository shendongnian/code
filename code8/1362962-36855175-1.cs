    [TestMethod]
    public void Calling_GetAllStudents_ReturnsSortedListOfStudents()
    {
        var studentsList = new List<Student> {
        new Student {
                         Id = "123",
                         EnrollTime = "02/22/16 14:06:56 PM",
                         Course = 1
                     },
         new Student {
                         Id = "456",
                         EnrollTime = "03/30/16 12:50:38 PM",
                         Course = 2
                     }
                     };
        // mock out student repository to return list    
        var studentsList = _studentRepository.GetAllStudents();
        
        Assert.AreEqual(1, studentsList.Count);
        Assert.AreEqual("123", studentsList[0].Id);
    }
