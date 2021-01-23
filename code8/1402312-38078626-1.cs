    using System;
    using System.Linq;
    using System.Xml.Linq;
      public static string ReadNodeAttribute(string IDAttribute)
            {
                string _Value = "";
                try
                {
                   //I used System.IO.Path.GetFullPath because I tried it with ConsoleApplication.
                   //Use what ever work for you to load the xml.
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
