    [Test]
    public async Task GetSomethingAsync_CallsConverter()
    {
      int id = 123;
      await AssertEx.ThrowsAsync<NullReferenceException>(
          async () => await _repository.GetSomethingAsync(id));
      _fooMock.Verify(f => f.Bar(id), Times.Once);
    }
