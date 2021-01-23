    var data = new List<Employee>();
            data.Add(new Employee { EmployeeId = 1, Skillssetpoints = 10, Date = Convert.ToDateTime("4/5/2016 16:12:12") });
            data.Add(new Employee { EmployeeId = 2, Skillssetpoints = 12, Date = Convert.ToDateTime("3/5/2016 17:12:12") });
            data.Add(new Employee { EmployeeId = 3, Skillssetpoints = 4, Date = Convert.ToDateTime("8/5/2016 8:12:12") });
            data.Add(new Employee { EmployeeId = 4, Skillssetpoints = 20, Date = Convert.ToDateTime("1/5/2016 2:12:12") });
            var highestDate = data.OrderByDescending(e => e.Date).First().Date;
            var skillssetpointsList = data.Select(e => e.Skillssetpoints).ToList();
            EmployeeModel employeeModel = new EmployeeModel()
            {
                Date = highestDate,
                Skillssetpoints = skillssetpointsList
            };
            string jsonString = JsonConvert.SerializeObject(employeeModel);
            
