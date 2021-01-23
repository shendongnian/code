    public class Foo
    {
        public string propertyA { get { return list[0]; } set { list[0] = value; } }
        public string propertyB { get { return list[1]; } set { list[1] = value; } }
        public string propertyC { get { return list[2]; } set { list[2] = value; } }
        public List<string> list = new List<string>() {"", "", ""};
        public Foo()
        {
        }
    }
