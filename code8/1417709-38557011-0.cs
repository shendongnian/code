    [Fact]
    public void Delete()
    {
        // arrange
        var comment = new Comment("BodyText")
        {
            Audio = new Audio(),
            Date = DateTime.Now
        };
        // set up the repository’s Delete call
        _mockRepository.Setup(r => r.Delete(It.IsAny<Comment>()));
        // act
        _service.Delete(comment);
        // assert
        // verify that the Delete method we set up above was called
        // with the comment as the first argument
        _mockRepository.Verify(r => r.Delete(comment));
    }
