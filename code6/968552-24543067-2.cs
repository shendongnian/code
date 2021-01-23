    public class SimpleClass
    {
        [XmlIgnore]
        public ComplexClass Parent { get; set; }
        public Guid ComplexClassId { 
            get { return Parent.Id; } 
            set { Parent = new ComplexClass(value); } 
        }
    }
