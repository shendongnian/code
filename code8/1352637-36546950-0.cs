    [TestMethod]
    public void Test()
    {
      var resultOne = new HttpStatusCodeResult(400, null);
      var resultTwo = new HttpStatusCodeResult(400, null);
      // Assert
      Assert.AreEqual(resultOne.StatusCode, resultTwo.StatusCode);
      Assert.AreEqual(resultOne, resultTwo);
    }
