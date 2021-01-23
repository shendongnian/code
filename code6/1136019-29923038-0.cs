    public class MyType
    {
        public static MyType Empty = new MyType(String.Empty, DateTime.MinValue);
        public MyType(string myName, DateTime myBirthday)
        {
            MyName = myName;
            MyBirthday = myBirthday;
        }
        public DateTime MyBirthday { get; private set; }
        public string MyName { get; private set; }
    }
