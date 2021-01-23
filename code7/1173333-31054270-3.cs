    public void MyRepository_FindEntity_ReturnsExpectedEntity()
    {
      var id = 5;
      var expectedEntity = new MyType();
      var dbSet = Mock.Of<IDbSet<MyType>>(set => set.Find(It.is<int>(id)) === expectedEntity));
      var repository = new MyRepository(dbSet);
      
      var result = repository.FindEntity(id);
    
      Assert.AreSame(expectedEntity, result);
    }
