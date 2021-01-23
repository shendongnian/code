    [TypeDescriptionProvider(typeof(MyTypeDescriptionProvider))]
    public class MyCustomClass : Component
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Property3 { get; set; }
    }
