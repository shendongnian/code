    public class Model
    {
        public int Property1 { get; set; }
        [Editor(typeof(MyBoolEditor), typeof(UITypeEditor))]
        public bool Property2 { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Model Property3 { get; set; }
    }
