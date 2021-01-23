    public class MySetter
    {
        public MySetter(IOperationContext<string> stringContainer)
        {
            stringContainer["workingDirectory"] = "foo";
        }
    }
    
    public class MyGetter
    {
        public MyGetter(IOperationContext<string> stringContainer)
        {
            var workingDirectory = stringContainer["workingDirectory"];
        }
    }
