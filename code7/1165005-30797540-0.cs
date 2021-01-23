    public interface ITestInterface
    {
       string GetAProperty();
    }
    public class MyClass : ITestInterface
    {
        public string GetAProperty()
        {
            // Do work...
            return "Value";
        }
    }
