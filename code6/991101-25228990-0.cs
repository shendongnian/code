       private IEnumerable<Employee> EnumerateEmployees(ComplexDepartment complexDepartment)
        {            
            foreach (var department in complexDepartment.Departments)
            {                
                if (department is SimpleDepartment)
                {
                     var simpleDepartment = department as SimpleDepartment;
                     foreach(var e in GetEmployees(simpleDepartemnt))
                       yield return e;
                }
                else if (department is ComplexDepartment) 
                {
                    foreach(var e in EnumerateEmployees(department))
                       yield return e;
                }                
            }            
        }
