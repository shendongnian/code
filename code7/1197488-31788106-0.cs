    public class MyObjectList : ObservableCollection<object>
    {
        public MyObjectList()
        {
            Add(new KeyValuePair<string, int>("Key1", 1));
            Add(new KeyValuePair<string, string>("Key2", "Value2"));
            Add(new KeyValuePair<string, bool>("Key3", true));
            Add(new KeyValuePair<string, double>("Key4", 1.5));
            Add(new KeyValuePair<string, MyEnum>("Key5", MyEnum.OPTION3));
            Add(new KeyValuePair<string, MyCustomClass>("Key6", new MyCustomClass(123)));
        }
    }
    public class MyCustomClass
    {
        int value;
        public MyCustomClass(int value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return string.Format("MyCustomClass is {0}", value);
        }
    }
    enum MyEnum { OPTION1, OPTION2, OPTION3 };
