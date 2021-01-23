    class Program
    {
        //this is just for convenient storage of all collected data
        //also to avoid additional dictionary lookups and processing
        internal class ElementAttributes
        {
            public XElement Element { get; set; }
            public Dictionary<string, string> Attributes;
            public ElementAttributes(XElement element)
            {
                this.Element = element;
                this.Attributes = new Dictionary<string, string>();
            }
        }
        static void Main(string[] args)
        {
            //loading XML elements from embedded resources
            XElement parentItems = XElement.Parse(ResourceXML.parentItems);
            XElement childItems = XElement.Parse(ResourceXML.childItems);
            XElement diff = XElement.Parse(@"<tcm:ListItems xmlns:tcm=""http://www.tridion.com/ContentManager/5.0"" ></tcm:ListItems>");
            var parentDictionary = BuildDictionary(parentItems);
            var childDictionary = BuildDictionary(childItems);
            //perform diff
            foreach (string key in childDictionary.Keys)
            {
                ElementAttributes parentElementAttributes;
                if (parentDictionary.TryGetValue(key, out parentElementAttributes))
                {
                    //found Title/key in parent, compare attributes
                    foreach (var childAttribute in childDictionary[key].Attributes)
                    {
                        var attributeName = childAttribute.Key;
                        var childAttributeValue = childAttribute.Value;
                        
                        string parentAttributeValue;
                        if (parentElementAttributes.Attributes.TryGetValue(attributeName, out parentAttributeValue))
                        {
                            //found attribute in parent, compare value
                            if(childAttributeValue == parentAttributeValue)
                            {
                                //values are equal, compare other attributes
                                continue;
                            }
                        }
                        //parent does not have this attribute OR
                        //different value in child -> show in diff
                        diff.Add(childDictionary[key].Element);
                        //do not compare other attributes
                        break;
                    }
                    //child may have missing attributes, which are in parent only
                    //NOTE: your example does not present a use case for this scenario
                    foreach (var parentAttribute in parentElementAttributes.Attributes)
                    {
                        string attributeName = parentAttribute.Key;
                        if (!childDictionary[key].Attributes.ContainsKey(attributeName))
                        {
                            //attribute found in parent, but not in child
                            diff.Add(childDictionary[key].Element);
                            break;
                        }
                    }
                }
                else
                {
                    //not found in parent, show in diff
                    diff.Add(childDictionary[key].Element);
                }
            }
        }
       
        private static Dictionary<string, ElementAttributes> BuildDictionary(XElement element)
        {
            XNamespace tcm = "http://www.tridion.com/ContentManager/5.0";
            var resultDictionary = new Dictionary<string, ElementAttributes>();
            foreach (XElement childElement in element.Elements(tcm + "Item"))
            {
                var attributeDictionary = new ElementAttributes(childElement);
                foreach (XAttribute attribute in childElement.Attributes())
                {
                    string[] excludedColumns = {"Title", "Modified"};
                    if (excludedColumns.Contains(attribute.Name.LocalName))
                    {
                        continue;
                    }
                    attributeDictionary.Attributes.Add(attribute.Name.LocalName, attribute.Value);
                }
                resultDictionary.Add(childElement.Attribute("Title").Value, attributeDictionary);
            }
            return resultDictionary;
        }
    }
