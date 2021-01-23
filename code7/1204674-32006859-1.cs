    var p = new PassValue();
    serviceMock.Stub(x => x.DoSomething(
                ref Arg<Poco>.Ref(p, p.Obj).Dummy, 
                ref Arg<int>.Ref(Rhino.Mocks.Constraints.Is.Equal(1), 2).Dummy))
                .WhenCalled(invocation =>
                {
                    invocation.Arguments[0] = p.Obj;
                });
