    public class AccountProfile
        {
            public string FirstName { get; set; }
            public string Lastname { get; set; }
        }
    public class OtherClass : AccountProfile 
        {
            //here you have access to FirstName and Lastname by inheritance
            public string Property1 { get; set; }
            public string Property2 { get; set; }
        }
