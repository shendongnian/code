    class A
    {
        public string S { get; set; }
    }
    [return: AssignAllProperties]
    public static A Create()
                    ~~~~~~
    {
        return new A();
    }
