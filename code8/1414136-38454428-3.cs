    public static class ThirdPartyExtensions
    {
        static Dictionary<string, string> map;
        static ThirdPartyExtensions()
        {
            map = new Dictionary<string, string>{ {"F_Name", "FirstName"} /*and others*/};
        }  
     
        public static Employee ConvertTo(this ThirdPartyEmployee thirdPartyEmployee)
        {
            var result = new Employee();
    
            if(map.Count < typeof(Employee).GetProperties().Count())
                throw new Exception("Forget to add mapping for new field!");
            
            foreach(var prop in typeof(ThirdPartyEmployee).GetProperties())
                if(map.ContainsKey(prop.Name))
                {
                    var temp = typeof(Employee).GetProperty(map[prop.Name]);
                    temp.SetValue(result, prop.GetValue(thirdPartyEmployee));
                }
    
            return result;
        }
    }
