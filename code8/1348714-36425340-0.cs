            for (int i = 1; i <= 4; i++)
            {
                Employee emp = new Employee();
                emp.EmployeeId = i;
                emp.Name = "Name" + i;
                emp.Skillssetpoints = i + 1;
                emp.Date = DateTime.Now.AddDays(i);
                lstEmp.Add(emp);
            }
            var data = lstEmp;
            var result = new EmployeeModel
            {
                Date = data.Max(p => p.Date),
                Skillssetpoints = data.Select(p => p.Skillssetpoints).ToList()
            };
            var JsonData = JsonConvert.SerializeObject(new
            {
                Date = result.Date,
                Skillssetpoints = result.Skillssetpoints
            });
