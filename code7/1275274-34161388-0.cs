    class Program
    {
        static string GetData()
        {
            return "double M = <M>2.0</M>" +
                   "double C = <C>0.59</C>" +
                   "double D = <D>0.48</D>" +
                   "double E = <E>0.69</E>";
        }
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            var variablesAndFunctions = doc.CreateElement("VariablesAndFunctions");
            doc.AppendChild(variablesAndFunctions);
            var constraints = doc.CreateElement("Constraints");
            constraints.InnerXml = GetData();
            variablesAndFunctions.AppendChild(constraints);
            Console.WriteLine(doc.OuterXml);
            Console.ReadLine();
        }
    }
