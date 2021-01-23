    public class Program
    {
        public static void Main(string[] args)
        {
            string xml = @"<?xml version='1.0' encoding='UTF-16'?>
    <apiRequest>
       <policyTransaction>
         <addDriver>
           <driverName>xyz</driverName>
           <IsCoInsured/>
           <OnlyInsuredWithThisPolicy/>
         </addDriver>
         <retrieveDrivers/>
         <validateDrivers/>
       </policyTransaction>
    </apiRequest>";
            XDocument doc = XDocument.Parse(xml);
            doc.Root.RemoveEmptyChildren("addDriver");
            Console.WriteLine(doc);
            Console.ReadKey();
        }
    }
    public static class XElementExtension
    {
        public static void RemoveEmptyChildren(this XElement element, XName name = null, bool recursive = false)
        {
            var children = name != null ? element.Descendants(name) : element.Descendants();
            foreach (var child in children.SelectMany(child => child.Elements()).ToArray())
            {
                if (child.IsEmpty || string.IsNullOrWhiteSpace(child.Value))
                    child.Remove();
            }
        }
    }
}
