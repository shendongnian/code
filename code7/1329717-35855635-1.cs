        enum States 
        {
            Success,
            FileNotFound,
            ...
        }
        class Result
        {
            public string[] Lines { get; set; }
            public States State { get; set; }
        }
        private Result LoadFile() 
        {
            // You code here
            ...
        }
