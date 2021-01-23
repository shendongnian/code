	namespace ConsoleApplication4
	{
		using System;
		using System.Linq;
		using System.Xml.Linq;
		internal class Program
		{
			private static void Main(string[] args)
			{
				var xmlDocument = XElement.Load(@"c:\tmp\foo.xml");
				// Loop over all elements having a "name" attribute starting with "cf_item".
				foreach (var pairElement in xmlDocument.Elements().Where(x => x.Attributes().Any(y => y.Name == "name" && y.Value.StartsWith("cf_item"))))
				{
					// Is there a child element, having a "name" attribute set to "cf_id" with a value of "34"?
					if (pairElement.Elements().Any(x => x.Attributes().Any(y => y.Name == "name" && y.Value == "cf_id") && x.Value == "34"))
					{
						// Fetch the single element with a "name" attribute set to "value".
						var valueElement = pairElement.Elements().Single(x => x.Attributes().Any(y => y.Name == "name" && y.Value == "value"));
						// Output the value of it!
						Console.WriteLine(valueElement.Value);
					}
					else
					{
						Console.WriteLine("No cf_id set to 34.");
					}
				}
			}
		}
	}
