    [TestMethod]
    public void TestMethod1()
    {
        var wasCalled = false;
        var fakeService = MockRepository.GenerateStub<IExternalInterface>();
        fakeService.Stub(x => x.GetExternalData(1))
                   .Return(new List<ExternalData>() {new ExternalData() {Id = 1}});
        fakeService.Stub(service => service.ExecuteService(Arg<Func<IExternalInterface, 
                         List<ExternalData>>>.Is.Anything, Arg<string>.Is.Anything))
                   .WhenCalled(invocation =>
                   {
                       wasCalled = true;
                       var func = (Func<IExternalInterface, List<ExternalData>>) invocation.Arguments[0];
                       var res = func(fakeService);
                       
                       //
                       // Assert here the "res"
                       //
                   }).Return(null);
        var target = new MyClass(fakeService);
        
        target.GetResultData(1);
        
        Assert. IsTrue(wasCalled);
    }
