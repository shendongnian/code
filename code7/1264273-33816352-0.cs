    [Serializable]
    public class InheritedClass : BaseClass
    {
        public string StringId { get; set; }
        [OptionalField]
        int intId;
        public int IntId { get { return intId; } set { intId = value; } }
    }    
