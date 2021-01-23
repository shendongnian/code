    List<string> items = class1.GetListOfStrings(494);
    
    Mock.Get(someRepository).Verify(repository => repository.GetSomeItems(It.Is<string[]>(strings => strings.SequenceEqual(items.GetRange(0, 100)))), Times.Once);
    Mock.Get(someRepository).Verify(repository => repository.GetSomeItems(It.Is<string[]>(strings => strings.SequenceEqual(items.GetRange(100, 100)))), Times.Once);
    Mock.Get(someRepository).Verify(repository => repository.GetSomeItems(It.Is<string[]>(strings => strings.SequenceEqual(items.GetRange(200, 100)))), Times.Once);
    // ...
