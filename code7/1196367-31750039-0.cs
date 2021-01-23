    public class iProperty : PropertyDescriptor
    {
        private string propName;
        private object propValue;
        // Need Parameterless Construtor ?
        public iProperty()
            : base("placeholder", new Attribute[] { })
        {
        }
        public iProperty(string pName, object pValue)
            : base(pName, new Attribute[] { })
        {
            propName = pName;
            propValue = pValue;
        }
    }
