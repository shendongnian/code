    using System;
    using System.Linq;
    using System.Xml.Linq;
      public static string ReadNodeAttribute(string IDAttribute)
            {
                string _Value = "";
                try
                {
                    XDocument xdoc = XDocument.Load(System.IO.Path.GetFullPath("XMLFile1.xml"));
                    var myValue = xdoc.Descendants("Value").FirstOrDefault(i => i.Attribute("ID").Value == IDAttribute);
                    if (myValue != null)
                    {
                        _Value = myValue.Attribute("Content").Value;
    
                        return _Value;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
    
                return _Value;
            }
