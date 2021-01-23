    public void UpdateMethod(XElement element)
    {
      XElement toUpdate = element.Descendants("ElementName").First();
      toUpdate.SetAttributeValue("AttributeName", "AttributeValue");
    }
