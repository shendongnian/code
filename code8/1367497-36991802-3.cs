    class Test
    {
        // Could assign this in the second constructor
        public bool AllowsDuplicates { get; } = 5;
        // Cannot assign this in the second constructor
        public bool AllowsDuplicates => 5;
        public Test()
        {
            // Default value used
        }
        public Test(bool value)
        {
            AllowsDuplicates = value;
        }
    }
