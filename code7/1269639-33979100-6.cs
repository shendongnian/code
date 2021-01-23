    [Fact]
    public void InvalidSMS()
    {
      Exception ex = Assert.Throws<Exception>(() => YourClass.create("S12345"));
      Assert.Equal("I don't like content!!!!!!!!!!", ex.Description);
    }
