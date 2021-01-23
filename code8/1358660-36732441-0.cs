    [TestClass]
    public class JsonToXmlTests : MiscUnitTests {
        [TestMethod]
        public void Xml_Should_Convert_To_JSON_And_Object() {
            string xml = "<POSLog MajorVersion=\"6\" MinorVersion=\"0\" FixVersion=\"0\"><Cash Amount = \"100\"></Cash></POSLog>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
            //Attributes are prefixed with an @ and should be at the start of the object.
            jsonText = jsonText.Replace("\"@", "\"");
            POSLog actual = JsonConvert.DeserializeObject<POSLog>(jsonText);
            actual.Should().NotBeNull();
            actual.MajorVersion.Should().Be("6");
            actual.MinorVersion.Should().Be("0");
            actual.FixVersion.Should().Be("0");
            actual.Cashx.Should().NotBeNull();
            actual.Cashx.Amount.Should().Be("100");
        }
        public class Cash {
            public string Amount { get; set; }
        }
        public class POSLog {
            public string MajorVersion { get; set; }
            public string MinorVersion { get; set; }
            public string FixVersion { get; set; }
            public Cash Cashx { get; set; }
        }
    }
