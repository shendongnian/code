    There is a basic inconsistency between XML and JSON in that XML does not have the concept of an array.  It merely has sequences of elements with names.  So, under what circumstances does Json.NET create arrays?  From [Converting between JSON and XML](http://www.newtonsoft.com/json/help/html/ConvertingJSONandXML.htm):
     > Multiple nodes with the same name at the same level are grouped together into an array.
    However, what you have a multi-level list, like so:
        <Container>
            <element>
            </element>
            <!-- Repeat as necessary -->
        </Container>
    Json.NET will not automatically recognize the container element as an array, thus you will need to pre-process the XML with [LINQ to XML](https://msdn.microsoft.com/en-us/library/bb387098.aspx) or post-process with [LINQ to JSON](http://www.newtonsoft.com/json/help/html/LINQtoJSON.htm).  I think the latter is easier.  Luckily, all your list entries are named `element` making the post-processing straightforward.  It can be done with the following two extension methods:
        public static class JsonExtensions
        {
            public static JObject ToJObject(this XDocument xDoc)
            {
                // Convert to Linq to XML JObject
                var settings = new JsonSerializerSettings { Converters = new[] { new XmlNodeConverter { OmitRootObject = true } } };
                var root = JObject.FromObject(xDoc, JsonSerializer.CreateDefault(settings));
                // Convert two-level lists with "element" nodes to arrays.
                var groups = root.Descendants()
                    .OfType<JProperty>()
                    .Where(p => p.Name == "element")
                    .GroupBy(p => (JObject)p.Parent)
                    .Where(g => g.Key.Parent != null && g.Key.Properties().Count() == g.Count())
                    .ToList();
                foreach (var g in groups)
                {
                    // Remove values from properties to prevent cloning
                    var values = g.Select(p => p.Value)
                        .SelectMany(v => v.Type == JTokenType.Array ? v.Children().AsEnumerable() : new[] { v })
                        .ToList()
                        .Select(v => v.RemoveFromLowestPossibleParent());
                    g.Key.Replace(new JArray(values));
                }
                return root;
            }
            public static JToken RemoveFromLowestPossibleParent(this JToken node)
            {
                if (node == null)
                    throw new ArgumentNullException("node");
                var contained = node.AncestorsAndSelf().Where(t => t.Parent is JContainer && t.Parent.Type != JTokenType.Property).FirstOrDefault();
                if (contained != null)
                    contained.Remove();
                // Also detach the node from its immediate containing property -- Remove() does not do this even though it seems like it should
                if (node.Parent is JProperty)
                    ((JProperty)node.Parent).Value = null;
                return node;
            }
        }
    Then just do:
            var xDoc = XDocument.Parse(xmlString);
            var root = xDoc.ToJObject();
            var jsonString = root.ToString();
