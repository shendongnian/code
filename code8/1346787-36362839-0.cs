    using System.Xml.Linq;
    var doc = XDocument.Parse(/*XML file content*/); // or use XDocument.Load(...)
    var pattern = @".*[0-9a-zA-Z]{8}\-[0-9a-zA-Z]{4}\-[0-9a-zA-Z]{4}\-[0-9a-zA-Z]{4}\-[0-9a-zA-Z]{12}.*";
    doc.Descendants("file")
    	.Where(x => Regex.IsMatch((string)x.Attribute("reg"), pattern))
    	.Remove();
    var xmlContent = doc.ToString(); // or just doc.Save()
