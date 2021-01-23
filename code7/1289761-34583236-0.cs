    static void Main(string[] args)
            {
                string xml = @"<ParentNode>
        <Items>
            <Request>
                <IsValid>True</IsValid>
                <ItemLookupRequest>
                <Item>
                    <ASIN>B001MS70F1</ASIN>
                    <OfferSummary>
                            <LowestNewPrice>
                                <Amount>1098</Amount>
                                <CurrencyCode>GBP</CurrencyCode>
                                <FormattedPrice>£15.98</FormattedPrice>
                            </LowestNewPrice>
                    </OfferSummary>
                </Item>
                </ItemLookupRequest>
            </Request>
        </Items>
        <Items>
            <Request>
                <IsValid>True</IsValid>
                <ItemLookupRequest>
                    <Item>
                        <ASIN>B001MS70212</ASIN>
                        <OfferSummary>
                                <LowestNewPrice>
                                    <Amount>1098</Amount>
                                    <CurrencyCode>GBP</CurrencyCode>
                                    <FormattedPrice>£10.98</FormattedPrice>
                                </LowestNewPrice>
                        </OfferSummary>
                    </Item>
                </ItemLookupRequest>
            </Request>
        </Items>
        </ParentNode>";
    
                XDocument doc = XDocument.Parse(xml);
    
                List<XElement> elements = doc.Descendants("Item").ToList();
    
                foreach(XElement elem in elements)
                {
                    string asin = elem.Element("ASIN").Value;
                    string formatedPrice = elem.Element("OfferSummary").Element("LowestNewPrice").Element("FormattedPrice").Value;
    //you can use this for formated price too
                    string formatedPrice2 = elem.Descendants("FormattedPrice").FirstOrDefault().Value;
                    Console.WriteLine("ASIN: " + asin + " and Price:" + formatedPrice);
                }
    
                Console.ReadKey();
            }
