    private static IAppBackendRepository _repo;
    public  StudentController(IAppBackendRepository repo)
    {
        _repo = repo;
    }
    public  IEnumerable<Student> GetStudents()
    {
        List<Student> students = _repo.Get();
        return students;
    }
}
    [TestMethod]
    public void ShouldCallRepo()
    {
        // With Rhino
        var mockRepo = MockRepository.GenerateStub<IAppBackendRepository>();
        var expectedResult = new List<Student>();
        mockRepo.Expect(x => x.Get()).Return(expectedResult);
        var controller = new StudentController(mockRepo);
        var actualResult = controller.GetStudents();
        mockRepo.VerifyAllExpectations();
        Assert.AreEqual(actualResult, expectedResult); // Possible in it's own method.
    }
