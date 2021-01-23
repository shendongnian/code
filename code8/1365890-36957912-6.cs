        static public XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
        static public XElement addNilAttributes(XElement root)
        {       
            IEnumerable<XElement> noValueElements =
                from el in root.Descendants()
                where (string)el.Attribute("nilReason") != null
                select el;
            
            foreach (XElement el in noValueElements)
            {
                el.Add(new XAttribute(xsi + "nil", "true"));
                el.ReplaceNodes(null); // make element empty
            }
            IEnumerable<XElement> nilElements =
                from el in root.Descendants()
                where (string)el.Attribute("nilReason") == null && (string)el.Attribute(xsi + "nil") != null
                select el;
            
            nilElements.Remove();
            return root;
        }
