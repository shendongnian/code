    public class AwesomeXml
    {
        public static void Main()
        {
            string xml = @"<root>  
                        <StandardValues>    
                        <ButtonYES>Ja</ButtonYES>
                        <ButtonNO>Nei</ButtonNO>
                        </StandardValues>
                        <Page1>
                        <Key_Head>2011 Applications</Key_Head>
                        <Key_Title>Title from 2011</Key_Title>
                        <Key_Param1>Parameter value</Key_Param1>
                        </Page1>
                        <Page2>
                        <Page_Head>2011 Applications</Page_Head>
                        <page_Title>Title from 2011</page_Title>
                        <CustomParam1>Parameter value</CustomParam1>
                        </Page2>
                        </root>";       
            var doc = XDocument.Parse(xml);
            var result = ConvertXmlToDic(doc.Root);
            Console.Read();
        }
        private static object ConvertXmlToDic(XElement element)
        {            
            var result = element.Elements().
                Select(
                    e => new { Key = e.Name,
                               Value = (e.Descendants().Count() == 0) ? e.Value : ConvertXmlToDic(e)
                    }
                ).ToDictionary(e => e.Key, e => e.Value);
            return result;
        }        
    }
