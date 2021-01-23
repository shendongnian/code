    public class MyRequired : ValidationAttribute
    {
        public MyRequired() : base("My Custom Message")
        {
            
        }
 
        public override bool IsValid(object value)
        {
            //The validation logic, you can always expand on this
            //Obviously, make it more robust to handle all types
            return (value != null);
        }
    }
