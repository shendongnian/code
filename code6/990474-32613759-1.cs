        [HttpGet]
        [ODataRoute("EmployeesWithParameters(Ids={Ids})")]
        public IQueryable<Employee> EmployeesWithParameters([FromODataUri]string[] Ids)
        {
            IQueryable<Employee> result = db.Employees.Where(p => Ids.Contains(p.EmployeeId) );
            return result; ;
        }
