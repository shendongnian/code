    var repoMoq = new Mock<IRepository>();
    repoMoq.Setup(s=>s.GetStudentName(It.IsAny<int>)).Returns("Test Student");
    var bl = new StudentManagementBusinessLayerClass(repoMoq.Object);
    // To do : Assert Something now.
    // Ex : bl.GetStudent(234);
