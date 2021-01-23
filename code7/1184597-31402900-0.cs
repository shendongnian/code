    [Serializable]
    public abstract class BaseClass
    {
        [XmlIgnore]
        public virtual bool BaseMember { get; set; }
    
    }
    
    [Serializable]
    public class DerivedClass : BaseClass
    {
        public string DerivedMember { get; set; }
    }
    
    [Serializable]
    public class XmlIgnore : BaseClass
    {
        // no XmlIgnore
        public override bool BaseMember
        {
            get
            {
                return base.BaseMember;
            }
            set
            {
                base.BaseMember = value;
            }
        }
    }
