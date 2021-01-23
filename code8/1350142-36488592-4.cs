        public static TestCasesList Deserialize(TextReader reader)
        {
            var serializer = new XmlSerializer(typeof(XmlRoot));
            var root = (XmlRoot)serializer.Deserialize(reader);
            return root == null ? null : root.testcaseslist;
        }
