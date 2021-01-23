        public class ClassA : IDestination
        {
            public string Var1 { get; set; }
            public string Var2 { get; set; }
            public string Var3 { get; set; }
            public string Var4
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
            public string Var5
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
        }
        public class ClassB : IDestination
        {
            public string Var1 { get; set; }
            public string Var2 { get; set; }
            public string Var3 { get; set; }
            public string Var4 { get; set; }
            public string Var5 { get; set; }
        }
