    static void Main(string[] args)
    {
        using (var context = new FakeEntities())
        {
            var complaintList = new List<Complaint>()
            {
                new Complaint() {Description = "This is a Test"}
            };
            Context.Complaint.AddRange(complaintList);
            var employeeList = new List<Employee>()
            {
                new Employee() {FirstName = "John", Id = 1, LastName = "Doe"},
                new Employee() {FirstName = "Jane", Id = 2, LastName = "Doe"},
                new Employee() {FirstName = "Kid", Id = 3, LastName = "Smith"}
            };
            Context.Employee.AddRange(employeeList);
            //Just add entities to corresponding collections.
            employeeList[0].Complaints.Add(complaintList[0]);
            context.SaveChanges();
        }
    }
