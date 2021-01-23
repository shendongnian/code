    private void PopulateEmployees(ComplexDepartment complex, ComplexDepartment addTo)
    {            
        foreach (var dep in complex.Departments)
        {                
            if (dep is SimpleDepartment)
            {
                 var simple = dep as SimpleDepartment;
                 addTo.employees.Add(GetEmployee(simple));
            }
            else if (dep is ComplexDepartment) 
            {
                PopulateEmployees(dep as ComplexDepartment, addTo);
            }                
        }            
    }
    // Call it like
    PopulateEmployees(myDep, myDep);
