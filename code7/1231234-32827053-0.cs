    private static Expression<Func<Department, DepartmentDto>> CreateDepartmentDtoUnexpanded = d => new DepartmentDto
    {
        Manager = CreatePersonDto.Invoke(d.Manager),
        Employees = d.Employees.Select(employee => CreatePersonDto.Invoke(employee))
            .ToList(),
    };
    public static Expression<Func<Department, DepartmentDto>> CreateDepartmentDto = CreateDepartmentDtoUnexpanded.Expand();
