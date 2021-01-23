    public static List<EmployeeNested> ProcessEmployeeData(List<Employee> result)
            {
                return result.Where(x => x.EmployeeId.HasValue).GroupBy(x => x.EmployeeId.Value).Select(x => new EmployeeNested
                {
                    EmployeeId = x.Key,
                    EmployeeName = x.First().EmployeeName,
                    Locations = x.Select(s => new Location
                    {
                        LocationId = s.LocationId,
                        LocationName = s.LocationName
                    }).ToList(),
                    Designations = x.Select(s => new Designation
                    {
                        DesignationId = s.DesignationId,
                        DesignationName = s.DesignationName
                    }).ToList()
                }).ToList();
            }
