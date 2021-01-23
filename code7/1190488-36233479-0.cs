    var myFakedSoapClient = A.Fake<SomeSoapClient>();
    var myCustomServiceWhichUsesThatSoapClient = new MyService(myFakedSoapClient);
    myFakedSoapClient.CallsTo(e=>e.DoSomething(A<string>.Ignored)).WithAnyArgumemen().Returns(expectedfakeobject);
    myCustomServiceWhichUsesThatSoapClient.CallDoSomething();   
    myFakedSoapClient.CallsTo(e=>e.DoSomething(A<string>.Ignored)).MustHaveHappened();
