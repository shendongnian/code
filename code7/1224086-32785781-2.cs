    public class MyClass 
    {
        [TypeConverter(typeof(ListConverter))]
        public List<int> List { get; set; }
        public MyClass()
        {
            List = new List<int>();
        }
        [RefreshProperties(RefreshProperties.All)]
        [Description("Change this property to regenerate the List")]
        public int Count
        {
            get { return List.Count; }
            set { List = Enumerable.Range(1, value).ToList(); }
        }
    }
