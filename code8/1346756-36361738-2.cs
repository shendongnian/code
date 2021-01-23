    public class CustomHandleError:HandleErrorAttribute
    {
        public CustomHandleError():base()
        {
            View = "SomeView";
        }
        //rest of your implementation
    }
