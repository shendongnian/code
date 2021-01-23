    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    namespace MergeResx
    {
    class Program
    {
        static void Main(string[] args)
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),"resx");
            var x = MergeResxFiles(new [] { Path.Combine(folder,args[0]), Path.Combine(folder, args[1])});
            File.WriteAllText(Path.Combine(folder, "merged.xml"), x.ToString());
            Console.WriteLine("--done--");
            Console.ReadLine();
        }
        static XDocument MergeResxFiles(string[] files)
        {
            var allResources =
                from f in files
                let doc = XDocument.Load(f)
                from e in doc.Root.Elements("data")
                select Resource.Parse(e, f);
            var elements = new List<XElement>();
            var enumerable = allResources.GroupBy(r => r.Name).OrderBy(x=>x.Key).ToList();
            foreach (var g in enumerable)
            {
                elements.AddRange(MergeResources(g.Key, g));
            }
            Console.WriteLine("Terms: " + enumerable.Count());
            var output = new XDocument(new XElement("root", elements));
            return output;
        }
        private static IEnumerable<XElement> MergeResources(string name, IEnumerable<Resource> resources)
        {
            var grouped = resources.GroupBy(r => r.Value).ToList();
            if (grouped.Count == 1)
            {
                yield return grouped[0].First().Xml;
            }
            else
            {
                Console.WriteLine($"Duplicate entries for {name}");
                foreach (var g in grouped)
                {
                    var comments = g.Select(r => new XComment($"Source: {r.FileName}"));
                    yield return new XElement(
                        "data",
                        comments,
                        new XAttribute("name", name),
                        new XElement("value", g.Key));
                }
            }
        }
        class Resource
        {
            public string Name { get; }
            public string Value { get; }
            public string Comment { get; }
            public string FileName { get; }
            public XElement Xml { get; }
            public Resource(string name, string value, string fileName,string comment, XElement xml)
            {
                Name = name;
                Value = value;
                Comment = comment;
                FileName = fileName;
                Xml = xml;
            }
            public static Resource Parse(XElement element, string fileName)
            {
                string name = element.Attribute("name").Value;
                string value = element.Element("value").Value;
                string comment = element.Element("comment")?.Value;
                return new Resource(name, value, fileName, comment, element);
            }
        }
    }
 }
