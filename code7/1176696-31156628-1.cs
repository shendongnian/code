    [Serializable] // Set this attribute to the class that you want to serialize
    public class XMLColumns
    {
        public string FieldName { get; set; }
        public DataTemplate CellTemplate { get; set; }
        public DataTemplate GroupValueTemplate { get; set; }
        //public object EditSettings { get; set; }
    }
