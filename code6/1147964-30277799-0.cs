    public class Animal
    {
        [XmlElement(ElementName = "NAME")]
        public virtual string Name { get; set; }
        public virtual bool ShouldSerializeName() { return true; }
    } 
    public class Cat : Animal
    {
        public override bool ShouldSerializeName() { return false; }
        [XmlIgnore]
        public NameAndType Name2 { get; set; }
        [XmlElement(ElementName = "NAME")]
        public override string Name 
        { 
            get
            {
                return String.Format("{0} [Type:{1}]", Name2.Name, Name2.Type); 
            }
            set { } 
        }        
    }
