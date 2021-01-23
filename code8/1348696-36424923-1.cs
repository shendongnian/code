    using System;
    using System.Xml;
    namespace TestCon
    {
	    class Program
        {
		    private static XmlDocument TestDoc;
		    public static void Main(string[] args)
		    {
			    TestDoc = new XmlDocument();
			    TestDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>"+
						"<stringList>\n"+
                    	"<property1/>\n"+"<property2/>\n"+
		"<style>\n"+"<queryString>Who's on fist."+"</queryString>\n"+
		"</style>\n"+"<queryString>Who's on second."+"</queryString>\n"+
		"</stringList>");
			    XmlNodeList elemList = TestDoc.GetElementsByTagName("queryString");
			    foreach (XmlNode foundNode in elemList) 
			    {
				    Console.WriteLine(foundNode.InnerText);
		        }
			    Console.Write("Press any key to continue . . . ");
			    Console.ReadKey(true);
		    }
	    }
    }
