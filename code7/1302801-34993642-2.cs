        class MyClass
        {
            public int Id { get; set; }
            private string _Name1;
            private string _Name2;
            public string Name2
            {
                get { return _Name2; }
                set { _Name2 = value; }
            }
            public string Name1
            {
                get { return _Name1; }
                set { _Name1 = value; }
            }
            public string DisplayName
            {
                get { return _Name1 + _Name2; }
            }
        }
