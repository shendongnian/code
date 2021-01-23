    Type OType = typeof(List<Category>); 
    foreach (System.Reflection.PropertyInfo prop in OType.GetProperties())
    {
        Response.Write(prop.Name + "<BR>")
    } 
