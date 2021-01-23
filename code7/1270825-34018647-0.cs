    public class Xml
    {
        public static string XmlString = @"<Configuration>
    <Elements>
        <SubElement1></SubElement1>
        <SubElement2></SubElement2>
        <SubElement3></SubElement3>
    </Elements>
    </Configuration>";
        public static XDocument Randomize()
        {
            //rather keep a static random if u can
            var rand = new Random();
            var xdoc = XDocument.Parse(XmlString);
            var ele = xdoc.Root.Element("Elements");
            var shuffle = new XElement("Elements", ele.Elements().OrderBy(x => rand.Next()));
            ele.ReplaceWith(shuffle);
            return xdoc;
        }
    }
