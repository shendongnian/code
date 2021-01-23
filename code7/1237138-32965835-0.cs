    public class CustomClass
    {
        public int Id {get; set;}
        public string Name {get; set;}
        ....
    }
    //you  can pass in variables to this method...
    public List<CustomClass> GetCustomeClass()
    {
        //here you just need to ensure what you select matches the class(CustomClass).
        string query = "Select * from Table_XYS";
    
        List<CustomClass> res = context.Database.SqlQuery<CustomClass>(query).ToList();
        return res;
    
    }
