    public class MyClass
    {
        public const string Role = "Admin";
        [Authorize(Roles = Role)]
        public ActionResult Get()
        {
        }    
    }
