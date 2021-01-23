    using System.Xml.Linq;
    using System.Linq;
    using System.Xml;
    var xml = System.Xml.Linq.XElement.Parse(result);
    if (xml.Elements("success").FirstOrDefault().Value == "1")
    {
       // Process Success
       Console.WriteLine("All Worked!");
    }
    else
    {
       var errors = xml.Elements("errors");
       foreach (var error in errors.Elements("error"))
       {
         // read error messages
         Console.WriteLine(error.Value);
       }
    }
