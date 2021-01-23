    string xml = @"<Location>
                  <AChau>
                    <ACity>
                      <EHouse/>
                      <FHouse/>
                      <GHouse/>
                    </ACity>
    
                    <BCity>
                      <HHouse/>
                      <IHouse/>
                      <JHouse/>
                      <KHouse/>
                    </BCity>
                  </AChau>
                </Location>";
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    XmlNode root = doc.DocumentElement;
    XmlNode first = root.FirstChild;
