	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Xml.Serialization;
	namespace soans
	{
		public class Test
		{
			//problematic attribute (ref is reserved)
			 [XmlAttribute(AttributeName="ref")]
			 public string RefAttr {get;set;}
			 //other attributes as well
			 [XmlAttribute()]
			 public string Field { get; set; }
		}
		class Program
		{
			static void Main(string[] args)
			{
				string filename = ""; //use your path here
				Test original = new Test()
				{
					RefAttr = "ref",
					Field = "test"
				};
				//serialiser
				XmlSerializer ser = new XmlSerializer(typeof(Test));
				//save to file
				TextWriter writer = new StreamWriter(filename);
				ser.Serialize(writer, original);
				writer.Close();
				//read from file
				TextReader reader = new StreamReader(filename);
				var fromfile = ser.Deserialize(reader) as Test;
				if(fromfile!=null)
				{
					Console.WriteLine(fromfile.RefAttr);
				}
                reader.Close();
				Console.ReadKey();
			}
		}
	}
