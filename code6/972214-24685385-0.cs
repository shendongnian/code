            var fields = new List<FieldDefinition>
            {
                new FieldDefinition{ Type="string", DisplayName="FirstName"},
                new FieldDefinition{ Type="int", DisplayName="EmployeeId"}
            };
            
            var infr = new List<Infrastructure>
            {
                new Infrastructure { def1=fields.FirstOrDefault()}// loop through to assign each item
            };
            foreach (var item in infr)
            Console.WriteLine(item.def1.DisplayName + " -" + item.def1.Type);
            
            Console.Read();
           
        }
    }
    public class Infrastructure
    {
        public FieldDefinition def1 { get; set; }
        
    }
    public class FieldDefinition
    {
        public string Type { get; set; }
        public string DisplayName { get; set; }
    }
