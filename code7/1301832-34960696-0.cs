    public class FakeContextFactory
    {
         public ControllerContext Create() {/*your mocking code*/}
         public ControllerContext Create(NameValueCollection formVariables) {...}
         ...
    }
    public void Test()
    {
        var context = new FakeContextFactory().Create();
        ...
    }
