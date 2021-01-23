    using System.Xml.Linq;
    namespace XmlReplacer
    {
	    class Program
	    {
		    static void Main(string[] args)
		    {
			    var doc1 = XDocument.Load(@"d:\temp\file1.xml");			         
                var doc2 = XDocument.Load(@"d:\temp\file2.xml");
  			    var specElement1 = doc1.Root.Element("General").Element("Instrument").Element("Specific");
			    var specElement2 = doc2.Root.Element("Specific");
			    specElement1.RemoveAll();
			    foreach (var xElement in specElement2.Elements())
			    {
				    specElement1.Add(xElement);
			    }
			    doc1.Save(@"d:\temp\file3.xml");
		    }
 	    }
    }
