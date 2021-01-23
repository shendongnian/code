        public class CustomAttribute<T> : CustomAttribute
        {
    		T _value;
    
    		[XmlIgnoreAttribute]
            public new T Value
            {
                get { return _value; }
                set { base.Value = value;
    				_value = value; }
            }
        }
