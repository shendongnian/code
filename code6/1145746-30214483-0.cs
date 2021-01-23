     public MyClass
        {
    
        [System.Xml.Serialization.XmlElement("b",IsNullable = false)]
            public object b
            {
                get
                {
                    return b;
                }
                set
                {
                    if (value == null)
                    {
                        b = null;
                    }
                    else if (value is DateTime || value is DateTime?)
                    {
                        b = (DateTime)value;
                    }
                    else
                    {
                        b = DateTime.Parse(value.ToString());
                    }
                }
            }
    
     //public object b ....
    
    }
