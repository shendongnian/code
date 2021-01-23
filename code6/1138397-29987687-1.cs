    public class MyRequired : RequiredAttribute
    {
        public MyRequired()
        {
            this.ErrorMessage = "Custom Validation Error Message.";
        }
    }
