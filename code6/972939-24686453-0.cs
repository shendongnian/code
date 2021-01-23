    public class UniqueUserEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var manager = new UserManager(new DbContext());
            //Find the email address            
            return true;
        }
    }
