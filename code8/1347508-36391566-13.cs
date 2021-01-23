    public class MyControllerTests
    {
      public void Index_Executed_ReturnsObjectWithSameId
      {
        // Assign
        var repo = Substitute.For<IPersonRepository>();
        var expectedId = 1;
        repo.Get().Returns(new Person { Id = expected });
        var controller = new MyController(repo);
        // Act
        var result = controller.Index() as ActionResult<PersonVM>;
        // Assert
        Assert.That(expectedId, Is.EqualTo(result.Value.Id));
    }
