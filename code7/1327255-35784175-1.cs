    class A
    {
        public List<string> Messages { get; set; }
        public static void Test()
        {
            A obj = new A { Messages = new List<string> { "message1", "message2" } };
            PropertyInfo prop = typeof(A).GetProperty("Messages");
            List<string> messages = (List<string>)prop.GetValue(obj);
        }
    }
