     public class Person
        {
            string NameForOthers
            {
                get { return Name; }
                set
                {
                     Logger.MyLogMethod(_name, value, "Person name set by other place");
                    Name= value;
                }
            }
            public string NameForBinding
            {
                get { return Name; }
                set
                {
                     Logger.MyLogMethod(_name, value, "Person name set by binding");
                    Name= value;
                }
            }
            string Name
            {
                get { return _name; }
                set
                {
                     Logger.MyLogMethod(_name, value, "Person");
                    _name = value;
                }
            }
            private string _name;
        }
