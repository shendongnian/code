    [Authenticate]
    //All HTTP (GET, POST...) methods need "CanAccess"
    [RequiredRole("Admin")]
    [RequiredPermission("CanAccess")]
    public class Secured
    {
        public bool Test { get; set; }
    } 
