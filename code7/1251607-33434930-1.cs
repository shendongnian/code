    [TestMethod]
    public void PreventsReentrancy()
    {
      var mutex = ...;
      var firstLock = mutex.LockAsync();
      var secondLock = mutex.LockAsync();
      Assert.IsTrue(firstLock.IsCompleted);
      Assert.IsFalse(secondLock.IsCompleted);
    }
