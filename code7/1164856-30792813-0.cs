    public class Employee 
    {
        public string Surname { get; set; }
        public string Forename { get; set; }
        public int EmployeeID { get; set; }
        public DateTime PaymentDate { get; set; }
        public override string ToString()
        {
            return string.Join(", ", Surname, Forename, EmployeeID, PaymentDate);
        }
     }
