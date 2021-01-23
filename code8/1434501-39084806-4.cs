    [Fact]
    public void Example_test()
    {
    var context = new XrmFakedContext();
    var service = context.GetFakedOrganizationService();
    var salesOrder = new SalesOrder() { Id = Guid.NewGuid(), OrderNumber = 69 }; 
    context.Initialize(new List<Entity>() { salesOrder });
    //some stuff
    //....
    //Queries are automatically mocked so any LINQ,FetchXml, 
    //QueryExpression or QueryByAttrubute should return the values you had in 
    //the context initialisation or as a result of updates / creates during the test execution
    var result = context.CreateQuery<SalesOrder>().FirstOrDefault();
    Assert.Equal(result.OrderNumber, 69);
    }
