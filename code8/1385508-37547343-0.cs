    // Test
    public void Should_ChangeChildViewModel1SomeProperty_WhenCallingMethodThatIWantToTest()
    {
        // arrange -- IService is null because we don't mock 
        //   things that are not being used anyway
        var child1 = new ChildViewModel1(null)
        // act -- childViewModel2 is null because we don't mock 
        //   things that are not being used anyway
        new MainViewModel(child1, null).MethodThatIWantToTest();
        // assert -- access child1 directly instead of through the
        //   property MainViewModel.ChildViewModel1, because this
        //   makes the test more contained (fewer assumptions about
        //   MainViewModel class). You should however create a test
        //   checking that the ChildViewModel1 passed to the ctor
        //   really is returned by the property.
        Assert.Equal(child1.SomeProperty, "new value");
    }
