    using System;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            XNamespace pmlcore = "urn:autoid:specification:interchange:PMLCore:xml:schema:1";
            XNamespace pmluid = "urn:autoid:specification:universal:Identifier:xml:schema:1";
    
            var root = new XElement(pmlcore + "Sensor",
                 new XAttribute(XNamespace.Xmlns + "pmluid", pmluid.NamespaceName),
                 new XAttribute(XNamespace.Xmlns + "pmlcore", pmlcore.NamespaceName));
            Console.WriteLine(root);
        }
    }
