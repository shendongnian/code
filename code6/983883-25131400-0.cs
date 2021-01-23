    [TestMethod]
    public void Test2()
    {
        foo.Expect(f => f.SomeCondition()).Return(true).Repeat.Once();
        foo.Expect(f => f.SomeCondition()).Return(false).Repeat.Times(0, int.MaxValue);
        foo.Expect(f => f.SomeMethod()).Repeat.Once();
        example.Bar(foo);
        example.Bar(foo);
        example.Bar(foo);
        foo.VerifyAllExpectations();
    }
