      class CProjectObject
        {
            
            private String _name;
    
            public String Name
            {
                get { return _name; }
                set { _name = value; }
            }
    
            private List<String> _methods;
    
            public List<String> Methods
            {
                get { return _methods; }
                set { _methods = value; }
            }
    
            private List<String> _properties;
    
            public List<String> Properties
            {
                get { return _properties; }
                set { _properties = value; }
            }
    
            private List<String> _fields;
    
            public List<String> Fields
            {
                get { return _fields; }
                set { _fields = value; }
            }
    
            private List<String> _members;
    
            public List<String> Members
            {
                get { return _members; }
                set { _members = value; }
            }
    
            private List<String> _events;
    
            public List<String> Events
            {
                get { return _events; }
                set { _events = value; }
            }
    
            public CProjectObject()
            {
                _name = "Anonym";
                _fields = new List<string>();
                _properties = new List<string>();
                _methods = new List<string>();
                _members = new List<string>();
                _events = new List<string>();
            }
    
            private CProjectObject(String name) : this()
            {
                _name = name;
            }
    
            public static CProjectObject CreateProjectObjectWithName(String name) 
            {
                return new CProjectObject(name);
            }
    
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("ObjectName:" + _name);
                builder.AppendLine("-Contains the following fields");
                foreach (String str in Fields) 
                {
                    builder.AppendLine("\tField:" + str);
                }
                builder.AppendLine("-Contains the following properties");
                foreach (String str in Properties)
                {
                    builder.AppendLine("\tProperty:" + str);
                }
                builder.AppendLine("-Contains the following methods");
                foreach (String str in Methods)
                {
                    builder.AppendLine("\tMethod:" + str);
                }
                builder.AppendLine("-Contains the following members");
                foreach (String str in Members)
                {
                    builder.AppendLine("\tMember:" + str);
                }
                builder.AppendLine("-Contains the following events");
                foreach (String str in Events)
                {
                    builder.AppendLine("\tEvent:" + str);
                }
    
                return builder.ToString();
            }
        }
