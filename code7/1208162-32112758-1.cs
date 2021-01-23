    public class ProcessXml
        {
            public void ReadXml()
            {
                var xml =
                    "<ArrayOfEndpointInfo xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
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
                var writer = XmlWriter.Create(@"D:\temp\myXml.xml");//Here you can use different overload to get xml in string, eg TextWriter etc.
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
    [XmlRoot(ElementName = "ConnectedChannels")]
    public class ConnectedChannels
    {
        [XmlElement(ElementName = "ConnectedChannel")]
        public List<string> ConnectedChannel { get; set; }
    }
    [XmlRoot(ElementName = "PairedEndpoint")]
    public class PairedEndpoint
    {
        [XmlElement(ElementName = "ConnectedChannels")]
        public ConnectedChannels ConnectedChannels { get; set; }
    }
    [XmlRoot(ElementName = "PairedEndpoints")]
    public class PairedEndpoints
    {
        [XmlElement(ElementName = "PairedEndpoint")]
        public List<PairedEndpoint> PairedEndpoint { get; set; }
    }
    [XmlRoot(ElementName = "EndpointInfo")]
    public class EndpointInfo
    {
        [XmlElement(ElementName = "PairedEndpoints")]
        public PairedEndpoints PairedEndpoints { get; set; }
    }
    [XmlRoot(ElementName = "ArrayOfEndpointInfo")]
    public class ArrayOfEndpointInfo
    {
        [XmlElement(ElementName = "EndpointInfo")]
        public EndpointInfo EndpointInfo { get; set; }
    }
