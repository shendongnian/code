    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.Web.Script.Serialization;
    namespace CommandLineProgram
    {
        public class DefaultProgram
        {
            public static void Main()
            {
                var kid1 = new kid() 
                { 
                    age = 10, 
                    name = "Jane", 
                    toys = new List<String> 
                    { 
                        "one", 
                        "two", 
                        "three" 
                    } 
                };
    
                var asdf = new
                {
                    age = kid1.age,
                    name = kid1.name,
                    toy_1 = kid1.toys[0],
                    toy_2 = kid1.toys[1],
                    toy_3 = kid1.toys[2]
                };
    
                JavaScriptSerializer ser = new JavaScriptSerializer();
    
                String serialized = ser.Serialize(asdf);
                Console.WriteLine(serialized);
            }
        }
    
        public class kid
        {
            public int age;
            public String name;
            public List<String> toys;
        }
    }
