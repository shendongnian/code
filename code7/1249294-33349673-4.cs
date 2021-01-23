    [AspNetCompatibilityRequirements(RequirementsMode = 
      AspNetCompatibilityRequirementsMode.Allowed)]
    public class AngularService : IAngularService
    {
      public HelloWorld GetHello()
      {
        return new HelloWorld { Message = "Hello from WCF. Time is: " +
          DateTime.Now.ToString() };
      }
    }
