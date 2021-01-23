    [TestMethod, Isolated]
    public void TestValidate()
    {
        //How to fake action context to further passing it as a parameter:
        var fake = Isolate.Fake.AllInstances<HttpActionContext>();
        Isolate.Fake.StaticMethods<HttpActionContext>();
                    
        //How to mock IsAjaxRequset:
        var request = new HttpRequestMessage();
        Isolate.WhenCalled(() => request.IsAjaxRequest()).WillReturn(true);            
        
        //Arrange:
        ValidateJsonAntiForgeryTokenAttribute target = new ValidateJsonAntiForgeryTokenAttribute();
        Isolate.WhenCalled(() => AntiForgery.Validate()).IgnoreCall();
                
        //Act:
        target.OnActionExecuting(fake);
        
        //Assert:
        Isolate.Verify.WasCalledWithAnyArguments(() => AntiForgery.Validate());
    }
