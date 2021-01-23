    [Fact]
    public void DeleteRestrictionsRepository()
    {
        const int DeletedId = 123;
        var mockRepository = new Mock<IRepository>();
        var repo = mockRepository.Object;
        var controller = new MyController(repo);
        controller.Delete(DeletedId);
        repo.Verify(v => v.DeleteRestrictions(DeletedID), Times.Once());
    }
