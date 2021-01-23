        public static string SetPageContent(string pageId, string msg)
        {
            string xml;
            onenoteApp.GetPageContent(pageId, out xml, PageInfo.piAll);
            var doc = XDocument.Parse(xml);
            // make newline with msg input
            XElement text = new XElement(ns + "OE",
                new XElement(ns + "T",
                    new XCData(msg)));
            // insert new line
            doc.Root.Element(ns + "Outline").Element(ns + "OEChildren").Add(text);
            // Now update the page content
            onenoteApp.UpdatePageContent(doc.ToString());
            return null;
        }
