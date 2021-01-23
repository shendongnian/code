    if (values.Length > 2 && values[2] != null)
    {
        return typeof(Department).GetProperty(values[2] as string).GetValue(department, null);
    }
    else 
    {
        //no property string passed - assume they just want the Department object
        return department;
    }
