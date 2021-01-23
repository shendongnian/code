    public class Employee
    {
        [CopyFromThirdPartyEmployee("F_Name")]
        public string FirstName { get; set; }
        [CopyFromThirdPartyEmployee("L_Name")]
        public string LastName { get; set; }
        [CopyFromThirdPartyEmployee("Telephone1")]
        public string MobileTelephone { get; set; }
    }
