    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    public class TestCase
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        public string version { get; set; }
        public string verdict { get; set; }
        public string objective { get; set; }
        public string criteria { get; set; }
        public string issue { get; set; }
        public string clientcomments { get; set; }
        public string authoritycomments { get; set; }
        public string sdk { get; set; }   
    }
					
    public class Program
    {
	    public const string XML = @"
    <TestCase name='TicketName'>
	    <name>Jon Nameson</name>
	    <version>10.1</version>
	    <verdict>High</verdict>
    </TestCase>
    ";
	
	    public static void Main()
	    {
		    var doc = new XmlDocument();
            doc.LoadXml(XML);
            var node = doc.SelectSingleNode("/TestCase");
		
		    var serializer = new XmlSerializer(typeof(TestCase));
		
		    var testcase = serializer.Deserialize(new StringReader(node.OuterXml)) as TestCase;
		
		    Console.WriteLine(testcase.name);
		    Console.WriteLine(testcase.version);
		    Console.WriteLine(testcase.verdict);
	    }
    }
