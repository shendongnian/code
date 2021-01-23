        public static List<XmlObject> FindTagsWithChildTags(string xml, string tag,string childTag,string attribute)
        {
            XDocument xdoc = XDocument.Load(xml);
            if (xdoc.Descendants(tag).Any())
            {
                var lv1s = (from lv1 in xdoc.Descendants(tag)
                            select new XmlObject
                            {
                                Element = "",
                                Value = lv1.Attribute(attribute).Value.ToLower(),
                                Field = attribute ,
                                XmlObjects = (from lv2 in lv1.Descendants(childTag)
                                             select new XmlObject
                                             {
                                                 Element="",
                                                 Field=lv1.FirstAttribute.Name.LocalName,
                                                 Value = lv1.FirstAttribute.Value.ToLower()
                                             }).ToList()
                            }).ToList();
                return lv1s;
            }
            return new List<XmlObject>();
        }
