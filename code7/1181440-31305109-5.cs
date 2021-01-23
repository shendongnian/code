        public static void Test()
        {
            string filePath = @"filename.xml";
            var xdoc = XDocument.Load(filePath);
            var repository = new XDocumentRepository(xdoc);
            string defName = "def";
            string defValue = "Some Test Value For Querying";
            Test(repository, defName, defValue, null); // Assert element not found.
            var test = new XElement(defName, new XAttribute("name", defValue));
            // Find the first deepest node in the document, for testing purposes.
            var node = xdoc.Descendants().OrderByDescending(e => e.AncestorsAndSelf().Count()).First();
            node.Add(test);
            Test(repository, defName, defValue, test); // Assert element found
            test.Attribute("name").Value = "fobar";
            Test(repository, defName, defValue, null); // Assert element not found when attribute value is changed
            test.Attribute("name").Value = defValue;
            Test(repository, defName, defValue, test); // Assert element found when attribute value restored
            test.Name = "flubber";
            Test(repository, defName, defValue, null); // Assert element not found when name changed
            test.Name = defName;
            Test(repository, defName, defValue, test); // Assert element found when name restored
            var parent = test.Parent;
            var parentParent = parent.Parent;
            test.Remove();
            Test(repository, defName, defValue, null); // Assert element not found when removed.
            parent.Add(test);
            Test(repository, defName, defValue, test); // Assert element found when added back
            if (parentParent != null)
            {
                parent.Remove();
                Test(repository, defName, defValue, null); // Assert element not found when parent removed.
                parentParent.Add(parent);
                Test(repository, defName, defValue, test); // Assert element found when parent added back.
            }
        }
        static void Test(XDocumentRepository repository, string elementName, string attributeValue, XElement expectedValue)
        {
            var xelm1 = repository.Document.Descendants(elementName).Where(d => (string)d.Attribute("name") == attributeValue).SingleOrDefault();
            var xelm2 = repository.ElementsByName(elementName).Where(d => (string)d.Attribute("name") == attributeValue).SingleOrDefault();
            Debug.Assert(xelm1 == xelm2 && xelm1 == expectedValue); // No assert
        }
