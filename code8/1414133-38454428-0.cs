    public static class ThirdPartyExtensions
    {
        public static Dictionary<string, string> map;
        static ThirdPartyExtensions()
        {
            map = new Dictionary<string, string>{ {"F_Name", "FirstName"} };
        }  
     
        public static Employee ConvertTo(this ThirdPartyEmployee thirdPartyEmployee)
        {
            var result = new Employee();
    
            if(map.Count() < typeof(Employee).GetProperties().Count())
                throw new Exception("Forget to add mapping for new field!");
            
            foreach(var prop in typeof(thirdPartyEmployee).GetProperties())
            {
                var temp = result.GetProperties().Where(x => x.Name == map[prop.Name]).First();
                temp.SetValue(result, prop.GetValue(thirdPartyEmployee));
            }
    
            return result;
        }
    }
