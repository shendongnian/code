    foreach(IProperty attribute in this.Element.OwnedAttributes)
    {
      string attributeList = GetProperty(attribute, "property", "ClrAttributes");
      if(!string.IsNullOrEmpty(attributeList))
      {
        //attributeList now will contain the attribute put in 
        //Streotypes>C# property>ClrAttributes
      }
    }
