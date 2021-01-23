    A a = new A();
    /////////
    a.Properties = new List<Property>()
    {
        new Property()
        {
            Type = Humanity.PropertyTypeEnum.String, // Now this property is useless, the value field has already a type, if you want you can add some logic around with this property to ensure that value will always be the same type
            Key = "name"
            Value = "file1.pdf"
        },
        new Property()
        {
            Type = Humanity.PropertyTypeEnum.Timestamp,
            Key = "creationDate",
            Value = Datetime.Now
        }
    }
    a.CreateProperties();
    dynamic dynA = a;
    dynA.name = "value1";
