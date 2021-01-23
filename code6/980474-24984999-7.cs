        public static void Test()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OrderDetail));
                OrderDetail orderDetail = (OrderDetail)serializer.Deserialize(new StringReader(TestString));
                string newTestString = TestWrite(serializer, orderDetail);
                var guid = DateTime.Now.Ticks;
                var path = Path.GetTempPath();
                var file1 = path + Path.DirectorySeparatorChar + "OldOrderDetail_" + guid.ToString() + ".xml";
                var file2 = path + Path.DirectorySeparatorChar + "NewOrderDetail_" + guid.ToString() + ".xml";
                File.WriteAllText(file1, TestString);
                File.WriteAllText(file2, newTestString);
            }
            catch (Exception e)
            {
                Debug.Assert(false, e.ToString());
            }
        }
        private static string TestWrite(XmlSerializer serializer, OrderDetail orderDetail)
        {
            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true; // For testing purposes, disable the xml version and encoding declarations.
                settings.Indent = true;
                settings.IndentChars = "    "; // The indentation used in the test string.
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", ""); // For testing purposes, disable the xmlns:xsi and xmlns:xsd lines, which were not in the test string.
                    serializer.Serialize(xmlWriter, orderDetail, ns);
                }
                return textWriter.ToString();
            }
        }
    }
