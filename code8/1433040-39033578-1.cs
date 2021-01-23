    [TestMethod]
    public void TestMethod1()
    {
        var fakeService = MockRepository.GenerateStub<IExternalInterface>();
        fakeService.Stub(x => x.GetExternalData(1)).Return(new List<ExternalData>() {new ExternalData() {Id = 1}});
        fakeService.Stub(service => service.ExecuteService(Arg<Func<IExternalInterface, 
                                                           List<ExternalData>>>.Is.Anything, Arg<string>.Is.Anything))
                   .Do(new Func<Func<IExternalInterface, List<ExternalData>>, string, List<ExternalData>>((func, str)=>func(fakeService)));
        var target = new MyClass(fakeService);
        
        var result = target.GetResultData(1);
        //
        // Assert here the "result"
        //
    }
