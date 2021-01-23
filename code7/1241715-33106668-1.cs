    var fakeStuRep = A.Fake<IStudentRepository>();
    A.CallTo(() => fakeStuRep.AllStudents()).Returns(new System.Collections.Generic.List<BE.Student> { new BE.Student { ID = 1, Age = 7 }, new BE.Student {ID = 2, Age = 55}});
          
    IStudentsBusinessLogic bl = new StudentsBusinessLogic(fakeStuRep);
    var res = bl.GetOldestStudent();
