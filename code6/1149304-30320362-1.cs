        var autoMocker = new RhinoAutoMocker<Foo>(MockMode.AAA);
        var barMock = autoMocker.Get<IBar>();
        autoMocker.ClassUnderTest.DoSomeThing();
        // Bara() should not be called more than four times
        barMock.AssertWasCalled(bar => bar.Bara(),     
                                options => options.IgnoreArguments().Repeat.Times(3,4));
 
