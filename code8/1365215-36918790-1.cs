    public class MyClass
    {
        public MyClass(int myInt, string myString)
        {
            this.MyInt = myInt;
            this.MyString = myString;
        }
        public int MyInt { get; private set; }
        public string MyString { get; private set; }
        public string Combo { get { return this.MyInt + this.MyString; } }
        public string AnUnrelatedReadWriteProperty { get; set; }
    }
