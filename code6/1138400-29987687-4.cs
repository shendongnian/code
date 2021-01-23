    public class MyRequired : ValidationAttribute
    {
        public MyRequired() : base("My Custom Message")
        {
            
        }
 
        public override bool IsValid(object value)
        {
            //Your custom validation logic
            return (value != null);
        }
    }
 
