    public class EmployeeFormViewModel
    {
         Employee Employee { get; set; }
         DateTime Date { get; set; }
         DateTime Time { get; set; }
        public void Post(int empid)
        {
            Employee= new Employee
            {
                EmployeeID = empid,
                DateTime = DateTime.Parse(string.Format("{0} {1}", Date, Time))
            };
            return;
    
        }
    }
