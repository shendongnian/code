    public class superclass
    {
        public string example;
        public class subclass: superclass
        {
            public class subsubclass: subclass
            {
                public new string example = "blahblah";
            }
        }
    }
