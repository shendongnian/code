    public static XmlElement AppendChildWithText(this XmlElement me, XmlDocument x, string name, string value) {
      var el = x.CreateElement(name);
      el.InnerText = value;
      me.AppendChild(el);
      return el; 
    }
