        // Option 1
        public IEnumerable<Employee> ReturnMessageFor
        {
            get
            {
                return messageFor;
            }
        }
        // Option 2
        public Employee[] ReturnMessageFor
        {
            get
            {
                return messageFor.ToArray();
            }
        }
