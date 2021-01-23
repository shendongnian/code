	public class UsersControllerTests
	{
		[TestMethod]
		public void Index_Always_CallsRepository()
		{
			// Arrange
			var repository = new Mock<IUsersRepository>();
			var controller = CreateValidUsersController(repository.Instance);
			
			// Act
			var result = controller.Index();
			
			// Assert
		    Assert.IsTrue(repository.IsCalled);
		}
		// Factory method to simplify creation of the class under test with its dependencies
		private UsersController CreateValidUsersController(params object[] deps) {
			return new UsersController(
				deps.OfType<IUsersRepository>().SingleOrDefault() ?? Fake<IUsersRepository>()
				// other dependencies here
				);
		}
		
		private static T Fake<T>() => (new Mock<T>()).Instance;
	}
