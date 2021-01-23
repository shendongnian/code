    public class TestClass
    {
        public static void Test()
        {
            var request = new Request
            {
                SName = "Hi",
                Message = new Message
                {
                    AddO = new AddO
                    {
                        CaseD = new CaseD { CaseA = new CaseA { Value = "Test Value" } },
                    }
                }
            };
            var xml = request.GetXml(XmlExtensions.NoStandardXmlNamespaces(), true);
            Debug.WriteLine(xml);
            var request2 = xml.LoadFromXML<Request>();
            Debug.WriteLine(request2.GetXml(XmlExtensions.NoStandardXmlNamespaces(), true));
            Debug.Assert(request.Message.AddO.CaseD.CaseA.Value == request2.Message.AddO.CaseD.CaseA.Value); // No assert.
        }
    }
