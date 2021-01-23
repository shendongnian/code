    [TestMethod]
    public void WhenSaveButtonClicked_ThenSaveMessageShouldBeShown()
    {
      // Arrange
      AsyncContext.Run(() =>
      {
        // Act
        View.SaveClicked += Raise.EventWith(new object(), new EventArgs());
      });
      // Assert
      Assert.AreEqual("Saved!", View.Message);
    }
