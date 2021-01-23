    public class Appointment
    {
        public DateTime AppointmentDateTime { get; set; }
        public Employee AppointmentEmployee { get; set; }
        public Appointment(DateTime AppointmentDateTime, Employee AppointmentEmployee)
        {
            this.AppointmentDateTime = AppointmentDateTime;
            this.AppointmentEmployee = AppointmentEmployee;
        }
    }
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        override public string ToString()
        {
            return string.Format("{0}, {1}", LastName, FirstName);
        }
    }
