    [Test]
    public void SelfContainedExampleTryCatch()
    {
      List<Exception> errors = new List<Exception>();
      try
      {
        AsyncContext.Run(() => ErrorAction());
      }
      catch (Exception ex)
      {
        errors.Add(ex);
      }
      errors.Count().Should().Be(1);
    }
