    class A
    {
        public List<string> Messages { get; set; }
        public static void Test()
        {
            A obj = new A { Messages = new List<string> { "message1", "message2" } };
            List<string> messages = new List<string>();
            PropertyInfo prop = typeof(A).GetProperty("Messages");
            messages = (List<string>)prop.GetValue(obj);
        }
    }
