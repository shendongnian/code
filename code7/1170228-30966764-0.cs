    [Test]
    public async Task Method_Scenario_IncreasesCount()
    {
        // Arrange
        const int employeeId = 55378008;
        var existingEntity = new MyObject {Employee = new Employee {Id = employeeId}};
        var repo = Mock.Of<IMyObjectRepo>(r => r.GetAll() == new[] {existingEntity}.AsQueryable());
        var uut = new MyUut(repo, Mock.Of<ILog>());
        // Act
        var entity = await uut.Contact(string.Empty, employeeId);
        // Assert
        Assert.That(entity.Contacts, Is.EqualTo(1));
        Mock.Get(repo).Verify(r => r.UpdateAsync(entity));
    }
