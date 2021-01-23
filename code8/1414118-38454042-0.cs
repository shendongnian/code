    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileTelephone { get; set; }
        public static Employee From(ThirdPartyEmployee employee)
        {
            var result = new Employee();
            result.FirstName = thirdPartyEmployee.F_Name;
            result.LastName = thirdPartyEmployee.L_Name;
            result.MobileTelephone = thirdPartyEmployee.Telephone1;
            return result;
        }
    }
