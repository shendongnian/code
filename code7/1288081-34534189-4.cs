        public class YourClass
        {
            private string _newGreeting;
            public string NewGreeting { get { return _newGreeting; } set { _newGreeting = value; } }
            public YourClass()
            {
                NewGreeting = "Test";
            }
        }
