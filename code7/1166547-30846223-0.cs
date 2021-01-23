     var stub = MockRepository.GenerateStub<ITempDA>();
     stub.Stub(x => x.Import(null))
         .IgnoreArguments()
         .WhenCalled(invocation =>
         {
             var arg = invocation.Arguments[0] as ...;
             // etc
         });
