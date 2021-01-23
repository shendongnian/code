    public void UpdateContact(XElement element)
    {
      XElement user = element.Element("user");
      user.SetAttributeValue("visible", "false");
    }
