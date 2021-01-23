    private void button6_Click(object sender, EventArgs e)
    {
        labelStatus.Text = "";
        
        var queryEmployees = employees.AsQueryable<Employee>();
        var queryDepartments = departments.AsQueryable<Department>();
        
        // the following section assumes Department is a Navigation Property of Employee: i.e. `employee.Departments`; 
        // (1 to many Relationship) - return string
        Expression<Func<Employee, string>> SelectEmployeeDepartmentsStringClause = (employee) => employee.Departments.Select((department) => String.Format("{0}, {1}, {2}", employee.Firstname, employee.Lastname, department.DepartmentName));
            
        // (1 to 1 Relationship) - return string
        Expression<Func<Employee, string>> SelectEmployeeDepartmentStringClause = (employee) => String.Format("{0}, {1}, {2}", employee.Firstname, employee.Lastname, employee.Department.DepartmentName);
        
        var query = queryEmployees.Select(SelectClause);
        // ===================================
        // (1 to 1Relationship) - returns EmployeeDepartmentDTO
        Expression<Func<Employee, EmployeeDepartmentDTO>> SelectEmployeeDepartmentDtoClause = (employee) => new EmployeeDepartmentDTO() {
                        Firstname = employee.Firstname,
                        Lastname =  employee.Lastname,
                        DepartmentName = employee.Department.DepartmentName
                    });
        // (1 to many Relationship) - returns EmployeeDepartmentDTO
        Expression<Func<Employee, EmployeeDepartmentDTO>> SelectEmployeeDepartmentsDtoClause = (employee) => new EmployeeDepartmentDTO() {
                        Firstname = employee.Firstname,
                        Lastname =  employee.Lastname,
                        DepartmentName = employee.Departments.Where( (department) => department.DepartmentId == employee.DepartmentId ).FirstOrDefault().DepartmentName
                    });
        // Dto to string;
        Expresssion<Func<EmployeeDepartmentDTO, string>> DtoSelectStringClause = (dto) => String.Format("{0}, {1}, {2}", dto.Firstname, dto.Lastname, dto.DepartmentName);
        var query = queryEmployees.Select(SelectClause).Select(DtoSelectClause);
        // ===================================
        // this following section assumes there is no Navigation Property, and no established relationship
    
        // This will be used in a Join Statement
        Expression<Func<Employee, Department, EmployeeDepartmentDTO>> JoinSelectDtoClause = (employee, department) => new EmployeeDepartmentDTO() {
                        Firstname = employee.Firstname,
                        Lastname =  employee.Lastname,
                        DepartmentName = department.DepartmentName
                    });
        var query = queryEmployees
                    .Join(queryDepartments.AsEnumerable(), (e) => e.DepartmentId, (d) => d.DepartmentId, JoinSelectClause)
                    .Select(DtoSelectClause);
        if (query.Count() > 0)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(query.ToArray());
            comboBox1.Text = "Employees and Departments Added!";
        }
    }
