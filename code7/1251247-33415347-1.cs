    [TestMethod]
    public void NoLazyLoadingAndNoEagerLoading()
    {
      var _db = new dbContext();
      var rooms = _db.Rooms.ToList();
      //All images will be null
      Assert.IsFalse(rooms.Any(x => x.Images != null));
      _db.Dispose();
    }
    [TestMethod]
    public void NoLazyLoadingAndNoEagerLoading()
    {
      var _db = new dbContext();
      var rooms = _db.Rooms.Include(x => x.Images).ToList();   
      //We have eager loaded them in the first query.
      Assert.IsTrue(rooms.Any(x => x.Images != null));
      _db.Dispose();
    
    }
