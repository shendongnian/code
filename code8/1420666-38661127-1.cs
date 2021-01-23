    public void Main()
    		{
                
                XmlDocument xdoc = new XmlDocument();
                
                // will ensure that XML exported will have opening tag
                // <?xml version="1.0" encoding="UTF-8"?>
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    ConformanceLevel = ConformanceLevel.Document,
                    OmitXmlDeclaration = false,
                    CloseOutput = true,
                    Indent = true,
                    IndentChars = "  ",
                    NewLineHandling = NewLineHandling.Replace
                };
    
                // strip out the <root> </root> tags on insert into string
                string strXML = Dts.Variables["User::PCC_XML"].Value.ToString().Replace("<ROOT>", "").Replace("</ROOT>", "");
                
                xdoc.LoadXml(strXML.ToString());
    
                // test destination
                using ( StreamWriter sw = File.CreateText("C:\\test_xml.xml") )
                using ( XmlWriter writer = XmlWriter.Create(sw, settings))
                {
                    xdoc.WriteContentTo(writer);
                    writer.Close();
                }
                
    			Dts.TaskResult = (int)ScriptResults.Success;
    		}
