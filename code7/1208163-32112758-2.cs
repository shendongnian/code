    public class ProcessXml
    {
        public void ReadXml()
        {
            var xml = "<ArrayOfEndpointInfo xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                    @"<EndpointInfo>
                        <PairedEndpoints>
                          <PairedEndpoint>
                            <ConnectedChannels>
                                <ConnectedChannel>1</ConnectedChannel>
                                <ConnectedChannel>2</ConnectedChannel>
                            </ConnectedChannels>
                          </PairedEndpoint>
                          <PairedEndpoint>
                            <ConnectedChannels>
                                <ConnectedChannel>3</ConnectedChannel>
                                <ConnectedChannel>4</ConnectedChannel>
                            </ConnectedChannels>
                          </PairedEndpoint>
                        </PairedEndpoints>
                      </EndpointInfo>
                    </ArrayOfEndpointInfo>";
            var serializer = new XmlSerializer(typeof(ArrayOfEndpointInfo));
            serializer.UnknownNode += Serializer_UnknownNode;
            serializer.UnknownAttribute += Serializer_UnknownAttribute;
            var result = serializer.Deserialize(GenerateStreamFromString(xml)) as ArrayOfEndpointInfo;
            WriteXml(result);
        }
    
        public void WriteXml(ArrayOfEndpointInfo info)
        {
            var writer = XmlWriter.Create(@"D:\temp\myXml.xml");//Here you can use different overload to get xml in variable, eg. TextWriter etc.
            var serializer = new XmlSerializer(typeof(ArrayOfEndpointInfo));
            serializer.Serialize(writer, info);
            writer.Close();
        }
    
    
        private static void Serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Nodes: {0}\t{1}", e.Name, e.Text);
        }
        private static void Serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            Console.WriteLine("Unknown Attributes: {0}\t{1}", e.Attr.Name, e.Attr.Value);
        }
        public Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
