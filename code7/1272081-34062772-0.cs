            public class MyObjects
            {
                public bool Active { get; set; }
                public List<ObjectName> OtherObjects { get; set; }
            }
    
            public class ObjectName
            {
                public string Name { get; set; }
                public List<OtherObject> OtherObjectProperties { get; set; }
            }
    
            public class OtherObject
            {
                public int Id { get; set; }
                public bool Enabled { get; set; }
                [ScriptIgnore]
                public string Address { get; set; }
                [ScriptIgnore]
                public string Name { get; set; }
            }
