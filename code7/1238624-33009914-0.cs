    public List<Employees> getEmployees(....... , int? takeMax = null)
    {
    // some code 
    ...
    
    if(takeMax != null)
    {
        return DB_Context.Employees.Where(%%%%% WHATEVER %%%%).Take(takeMax).ToList();
    }
    else
    {
        return return DB_Context.Employees.Where(%%%%% WHATEVER %%%%).ToList();
    }
