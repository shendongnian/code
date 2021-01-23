    class Test
    {
        // Could assign this in the second constructor
        public bool AllowsDuplicates { get; } = true;
        // Cannot assign this in the second constructor
        public bool AllowsDuplicates => true;
        public Test()
        {
            // Default value used
        }
        public Test(bool value)
        {
            AllowsDuplicates = value;
        }
    }
