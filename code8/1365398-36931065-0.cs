    public class MyClass
    {
        private List<string> myNames;
        public MyClass()
        {
            myNames = new List<string> { "jack", "pam", "phil", "suzan" };
        }
        [Browsable(false)]
        public List<string> Names
        {
            get { return myNames; }
        }
        [TypeConverter(typeof(MyConverter))]
        public string SelectedName { get; set; }
    }
