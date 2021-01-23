    [Fact]
    public void DeleteRestrictionsRepository()
    {
        const int DeletedId = 123;
        var mockRepository = new Mock<IRepository>();
        var controller = new MyController(mockRepository.Object);
        controller.Delete(DeletedId);
        mockRepository.Verify(v => v.DeleteRestrictions(DeletedID), Times.Once());
    }
