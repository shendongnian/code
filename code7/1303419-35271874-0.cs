    private FooEntity _itemToUpdate;
    private FooEntity _resultEntity;
    protected override void Arrange()
    {
        base.Arrange();
        var correctValue = "somevalue"
        _itemToUpdate = new FooEntity()
        _itemToUpdate.Email = correctValue;
        // Context is a mock of a DbContext and inherited from base class.
        Context.Expect(x => x.SaveChanges()).Return(0).WhenCalled(y =>
        {
            Assert.AreEqual(_resultEntity.Email, correctValue);
        });
        Context.Replay();
    }
    
    protected override void Act()
    {
        base.Act();
        // Repository is a mock of a repository and inherited from base class.
        _resultEntity = Repository.Update(_itemToUpdate);
    }
    
    [TestMethod]
    public void ShouldAssignEmailBeforeSave() // Assert
    {
       Context.VerifyAllExpectations();
    }
