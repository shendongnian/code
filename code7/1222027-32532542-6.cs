    public class ExpressionBuildingExample
    {
        private readonly System.Windows.Forms.Label labelStatus = new System.Windows.Forms.Label();
        private readonly System.Windows.Forms.ComboBox comboBox1 = new System.Windows.Forms.ComboBox();
        // 2 - DepartmentName, 0 - Firstname, 1 - Lastname (reorder for different results)
        private static readonly string itemFormat = "{2} - {0} {1}"; //used in String.Format
        #region "EmployeeDepartmentDTO to string"
        //  If you use a DTO, you'll do a Select<EmployeeDepartmentDTO, String> to produce a string value for each 'element' in the collection;
        private readonly Expression<Func<EmployeeDepartmentDTO, string>> DtoSelectClause = (dto) => String.Format(itemFormat, dto.Firstname, dto.Lastname, dto.DepartmentName);
        #endregion
        #region "Employee Department(s) to string(s)"
        //  ------------------------------------------------------------------------------------------------------------------------------------
        //  the following section assumes Department is a Navigation Property of Employee: i.e. `employee.Departments` or `employee.Department`; 
        //  ------------------------------------------------------------------------------------------------------------------------------------
        //  (1 to many Relationship) - return string[]
        private readonly Expression<Func<Employee, string[]>> SelectEmployeeDepartmentsStringClause = (employee) => employee.Departments.Select((department) => String.Format(itemFormat, employee.Firstname, employee.Lastname, department.DepartmentName)).ToArray();
        
        //  (1 to 1 Relationship) - return string
        private readonly Expression<Func<Employee, string>> SelectEmployeeDepartmentStringClause = (employee) => String.Format(itemFormat, employee.Firstname, employee.Lastname, employee.Department.DepartmentName);
        // =====================================================================================================================================
        #endregion
        
        #region "Employee Department(s) to IQueryable<EmployeeDepartmentDTO>"
        // (1 to 1Relationship) - returns EmployeeDepartmentDTO
        private readonly Expression<Func<Employee, EmployeeDepartmentDTO>> SelectEmployeeDepartmentDtoClause = (employee) => new EmployeeDepartmentDTO()
        {
            Firstname = employee.Firstname,
            Lastname = employee.Lastname,
            DepartmentName = employee.Department.DepartmentName
        };
        // (1 to many Relationship) - returns EmployeeDepartmentDTO
        private readonly Expression<Func<Employee, EmployeeDepartmentDTO>> SelectEmployeeDepartmentsDtoClause = (employee) => new EmployeeDepartmentDTO() {
            Firstname = employee.Firstname,
            Lastname =  employee.Lastname,
            DepartmentName = employee.Departments.Where( (department) => department.DepartmentId == employee.DepartmentId ).FirstOrDefault().DepartmentName
        };
        // =====================================================================================================================================
        #endregion
        #region "Employee JOIN Department to IQueryable<EmployeeDepartmentDTO>"
        // This will be used in a Join Statement
        private readonly Expression<Func<Employee, Department, EmployeeDepartmentDTO>> JoinSelectDtoClause = (employee, department) => new EmployeeDepartmentDTO()
        {
            Firstname = employee.Firstname,
            Lastname = employee.Lastname,
            DepartmentName = department.DepartmentName
        };
        // =====================================================================================================================================
        #endregion
        public void button6_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "";
            List<Department> departments = new List<Department>(new Department[] {
                new Department() { DepartmentId = 1, DepartmentName = "Sales" },
                new Department() { DepartmentId = 3, DepartmentName = "Manager" },
                new Department() { DepartmentId = 5, DepartmentName = "Reception" },
                new Department() { DepartmentId = 6, DepartmentName = "Human Resources" },
            });
            List<Employee> employees = new List<Employee>(new Employee[] {
                new Employee() { 
                    Firstname = "Dwight", Lastname = "Schrute", 
                    DepartmentId = 1,
                    Department = departments.First(d => d.DepartmentId == 1),
                    Departments = new List<Department>(departments.Where(d => d.DepartmentId == 1))},
                new Employee() { Firstname = "Jim", Lastname = "Halpert", 
                    DepartmentId = 1, 
                    Department = departments.First(d => d.DepartmentId == 1),
                    Departments = new List<Department>(departments.Where(d => d.DepartmentId == 1))},
                new Employee() { Firstname = "Mimi", Lastname = "Bobeck", DepartmentId = 5,
                    Department = departments.First(d => d.DepartmentId == 5),
                    Departments = new List<Department>(departments.Where(d => d.DepartmentId == 5))},
                new Employee() { Firstname = "Drew", Lastname = "Carry", DepartmentId = 6,
                    Department = departments.First(d => d.DepartmentId == 6),
                    Departments = new List<Department>(departments.Where(d => d.DepartmentId == 3))},
                new Employee() { Firstname = "Nigel", Lastname = "Wick", DepartmentId = 3,
                    Department = departments.First(d => d.DepartmentId == 3),
                    Departments = new List<Department>(departments.Where(d => d.DepartmentId == 3))},
                new Employee() { Firstname = "Micheal", Lastname = "Scott", DepartmentId = 5,
                    Department = departments.First(d => d.DepartmentId == 6),
                    Departments = new List<Department>(departments.Where(d => d.DepartmentId == 1))}
            });
            
            var queryEmployees = employees.AsQueryable<Employee>();
            var queryDepartments = departments.AsQueryable<Department>();
            
            var querySimple = queryEmployees.Select(SelectEmployeeDepartmentStringClause);
            var queryAdvanced = queryEmployees.Select(SelectEmployeeDepartmentsStringClause).SelectMany(s => s);
            var queryDto = queryEmployees.Select(SelectEmployeeDepartmentDtoClause);
            var queryJoin = queryEmployees.Join(queryDepartments.AsEnumerable(), (emp) => emp.DepartmentId, (dept) => dept.DepartmentId, JoinSelectDtoClause);
            
            var queryAll = new IQueryable<string>[] {
                querySimple,          
                queryAdvanced,
                queryDto.Select(DtoSelectClause),
                queryJoin.Select(DtoSelectClause),
            };
            if (queryAll.Any(q => q.Any())) //queryJoin.Any() + querySimple.Any() + queryDto.Any()
            {
                //  query.AsEnumerable() (or .ToList(), ToArray()) will load/execute/run the query;
                //  SelectMany will Enumerate the collections when it flattens them; thus it will load the queries;
                string[] items = queryAll
                        .SelectMany((q) => q)
                        .GroupBy(str => str).Select(g => g.Key) // the items are all strings (value types), so this will function properly; otherwise every instance would be unique and grouped, unless object.GetHashCode is overridden.
                        .ToArray();
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(items);
                comboBox1.Text = "Employees and Departments Added!";                
            }
        }
    }
