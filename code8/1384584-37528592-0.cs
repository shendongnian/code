    public class MyModel
    {
        [TypeConverter(typeof(MyTypeConverter))]
        public StringDictionary MyProp { get; set; }
    }
