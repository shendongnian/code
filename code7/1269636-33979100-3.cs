    [Fact]
    public void NullBody()
    {
      Assert.Throws<ArgumentNullException>("body", () => YourClass.create(null));
    }
    [Fact]
    public void EmptyBody()
    {
      Assert.Throws<ArgumentException>("body", () => YourClass.create(""));
    }
