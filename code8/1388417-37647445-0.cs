    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Reflection;
    using System.Linq;
    
    public class Program
    {
    
        public class Man
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }
    
        public static void Main()
        {
            var man = new Man
            {
                Id = 2,
                Name = "A Name",
                Phone = "123456789"
            };
    
            var props = "id,name";
    
            var customPropsArray = props.Split(',');
    
            Type t = man.GetType();
            PropertyInfo[] properties = t.GetProperties(
                BindingFlags.NonPublic | // Include protected and private properties
                BindingFlags.Public | // Also include public properties
                BindingFlags.Instance // Specify to retrieve non static properties
                );
    
            var dynamicObject = new ExpandoObject() as IDictionary<string, Object>;
    
            foreach (var p in properties.Where(x => customPropsArray.Contains(x.Name.ToLower())))
            {           
                dynamicObject.Add(p.Name, p.GetValue(man));
            }
        }
    }
