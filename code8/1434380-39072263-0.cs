    class Result {
    
        public string StringValue { get; }
        public string Int32Value { get; }
        public bool IsString { get; }
        public bool IsInt32 { get; }
        public Result(string value) {
            StringValue = value;
            IsString = true;
        }
        public Result(int value) {
            Int32Value = value;
            IsInt32 = true;
        }
    }
