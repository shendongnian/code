    readonly Mock<IBindingManager> bindingManager = new Mock<IBindingManager>();
        
    [Test]
    public void TestMethod()
    {
        Expression<Func<string, bool>> testExpression = binding => (binding == "Testing Framework");
            
        bindingManager.Setup(c => c.GetUserBinding(It.Is<Expression<Func<string, bool>>>(
            criteria => LambdaCompare.Eq(criteria, testExpression)))).Returns(new List<string>());
            
        var oc = new OtherClass(bindingManager.Object);
            
        var actual = oc.Test(b => b == "Testing Framework");
            
        Assert.That(actual, Is.Not.Null);
        bindingManager.Verify(c => c.GetUserBinding(It.Is<Expression<Func<string, bool>>>(
            criteria => LambdaCompare.Eq(criteria, testExpression))), Times.Once());
    }
