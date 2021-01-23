    public static Expression<Func<Department, DepartmentDto>> CreateDepartmentDto = d =>
         new DepartmentDto
            {
                Manager = CreatePersonDto.Compile()(d.Manager),
                Employees = d.Employees.Select(CreatePersonDto.Compile()).ToList() // Or declare Employees as IEnumerable and avoid ToList conversion
            };
