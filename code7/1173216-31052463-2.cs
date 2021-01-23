    var doc=XDocument.Parse(@"your xml");
    //Via Linq
    var viaLinq=doc.Elements()
      .SelectMany(e => e.Elements())
      .SelectMany(e => e.Elements())
      .SelectMany(e => e.Elements())
      .SelectMany(e => e.Elements())
      .Where(w => w.Attribute("OID").Value=="I_IMAGE_UPLOAD_XNAT")
      .Select(e => e.Attribute("Value").Value);
    //Even better use Xpath. It makes all this very simple
    var viaXPath=doc.XPathSelectElements("//Item[@OID='I_IMAGE_UPLOAD_XNAT']")
      .Select(e => e.Attribute("Value").Value);
