        public static void Test()
        {
            string xml1 = @"<Template Type=""Print"">
              <PrintWidth>7</PrintWidth>
              <PrintHeight>5</PrintHeight>
            </Template>";
            string xml2 = @"<Templates>
              <Template Type=""Print"">
                <PrintWidth>7</PrintWidth>
                <PrintHeight>5</PrintHeight>
              </Template>
              <Template Type=""Print"">
                <PrintWidth>7</PrintWidth>
                <PrintHeight>5</PrintHeight>
              </Template>
            </Templates>";
            var template1 = ExtractTemplate(xml1);
            var template2 = ExtractTemplate(xml2);
            Debug.Assert(template1 != null && template2 != null
                && template1.PrintWidth == template2.PrintWidth
                && template1.PrintWidth == 7
                && template1.PrintHeight == template2.PrintHeight
                && template1.PrintHeight == 5); // No assert
        }
        public static Template ExtractTemplate(string xml)
        {
            // Load the XML into an XDocument
            var doc = XDocument.Parse(xml);
            // Find the first element named "Template" with attribute "Type" that has value "Print".
            var element = doc.Descendants("Template").Where(e => e.Attributes("Type").Any(a => a.Value == "Print")).FirstOrDefault();
            // Deserialize it to the Template class
            var template = (element == null ? null : element.Deserialize<Template>());
            return template;
        }
