    [Test]
    public void ProductTypeService_WhenAddingNewItem_CallsSaveChanges()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        // setup the properties of the mock here...
        var service = new ProductTypeService(unitOfWork);
        service.Add(new ProductType { Id = 2, Description = "some product" });
        unitOfWork.AssertWasCalled(_ => _.SaveChanges());
    }
