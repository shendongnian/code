var xmlReader = XmlReader.Create(new StringReader(xml)); // Or whatever your source is, of course.
var myXDocument = XDocument.Load(xmlReader);
var namespaceManager = new XmlNamespaceManager(xmlReader.NameTable); 
namespaceManager.AddNamespace("prefix", "http://tempuri.org/TaskDetails.xsd"); // We add an explicit prefix mapping for our query.
XElement fatca = XElement.Parse(xml);
fatca.XPathSelectElement("//prefix:BankAccountNumber", namespaceManager).Value = "asd";
Console.WriteLine(fatca.ToString());
    ​
