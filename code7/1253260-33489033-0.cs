            var employee = new List<Person>() {
                new Person("FN", "LN", 1, new DateTime(1900, 1, 1), "", 1.1, 1),
                new Person("FN1", "LN1", 2, new DateTime(1900, 1, 1), "", 1.1, 1)
            };
            var invoices = new List<Invoice>() {
                new Invoice(1, 1, DateTime.Now, DateTime.Now, false),
                new Invoice(2, 2, DateTime.Now, DateTime.Now, false),
                new Invoice(3, 1, DateTime.Now, DateTime.Now, false),
            };
            Dictionary<string, List<Invoice>> result =
                employee.ToDictionary(e => string.Format("{0} {1}", e.FirstName, e.LastName),
                    e => invoices.Where(i => i.EmployeeId == e.ID).ToList());
