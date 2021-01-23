		public void MoviesController_Post_Without_Name()
		{
			// Arrange
			var model = new MovieModel();
			model.Name = "";
			// Act
			SimulateValidation(model);
			var result = controller.Post(model);
			// Assert
			Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
			Assert.AreEqual(6, controller.Get().Count());
		}
