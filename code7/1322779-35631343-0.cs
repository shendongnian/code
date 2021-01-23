    // Server-side CLR object
    class CoolObject
    {
        public string TypeName { get; set; }
        public IEnumerable<string> Values { get; set; }
    }
    // Client-side JSON sent to the server
    {
        TypeName: "MyType",
        Values: [
            "12",
            "asdf",
            "32.2"
        ]
    }
