	public void TestClassifyComments() {
		IEnumerable<Comment> spamComments = Builder<Comment>.CreateListOfSize(10).All()
			.With(x => x.Content = "spam spam spam")
			.Build();
		IEnumerable<Comment> hamComments = Builder<Comment>.CreateListOfSize(10).All()
			.With(x => x.Content = "ham ham ham")
			.Build();
		
		// Bring both lists together as one (might be a better way to do this)
		IEnumerable<Comment> allComments = spamComments.Union(hamComments);
		
		var mockRepository = new Mock<IGenericRepository<Comment>>();
		mockRepository
				.Setup(x => x.FindBy(It.Is<Expression<Func<Comment, bool>>>())
                .Returns( (Expression<Func<Comment, bool>> predicate => spamComments.Where(predicate));
				
		// Construct the class which has the ClassifyComments method
		var sut = ...;
		
		IEnumerable<Comment> ham;
		IEnumerable<Comment> spam;
		sut.ClassifyComments(out spam, out ham);
		
		Assert.That(spam.Length, Is.EqualTo(10));
		Assert.That(ham.Length, Is.EqualTo(10));				
	}
