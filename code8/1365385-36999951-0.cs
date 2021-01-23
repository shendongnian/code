      [TestMethod]
      public void verify_items_count()
      {
          //Arrange
          var expectedCount = 3;
          var repository = MakeRepositoryWithElements(expectedCount);
    
          //Act
          var actualCount = repository.Count();
          //Assert
          Assert.AreEqual(expectedCount, actualCount);
      }
