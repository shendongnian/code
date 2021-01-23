    XmlDocument doc = new XmlDocument();
                doc.LoadXml($@"
                            <result>
                                <xmldataHeader>
                                    <HeaderId> 1 </HeaderId>
                                    <xmldataDetail>
    	                            <DetailId> 1 </DetailId>
    	                            <DetailName> test </DetailName>
                                    </xmldataDetail>
                                </xmldataHeader> success
                                </result>");
                Console.WriteLine("Succes :" + doc.SelectSingleNode("result").LastChild.OuterXml);
                Console.WriteLine("xmldataHeader :"+doc.SelectSingleNode("result").FirstChild.OuterXml);
