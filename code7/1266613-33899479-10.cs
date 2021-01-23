    public class MyObject
    {
        public MyObject() { SomeSize = new Size(13, 13);  }
        public string SomeText { get; set; }
        [TypeConverter(typeof(CustomSizeConverter))]
        [DefaultValue(typeof(Size), "13,13")]
        public Size SomeSize { get; set; }
    }
    
