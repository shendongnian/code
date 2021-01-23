        public static TestCasesList Deserialize(TextReader reader)
        {
            using (var xmlReader = XmlReader.Create(reader))
            {
                // Skip to the <testcaseslist> element.
                if (!xmlReader.ReadToFollowing("testcaseslist", ""))
                    return null;
                var serializer = new XmlSerializer(typeof(TestCasesList));
                return (TestCasesList)serializer.Deserialize(xmlReader);
            }
        }
