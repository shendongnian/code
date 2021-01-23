    List<Employee>employees = new List<Employee>();  
    
    foreach (DataRow row in dt.Rows)  
    {  
        Employee emp= new Employee();
    
        PropertyInfo[] properties = typeof(Employee).GetProperties();
        for (int i = 0; i < properties.Length; i++)
        {
            property.SetValue(emp, Convert.ChangeType(row[i], property.GetType()));
        }
    }
