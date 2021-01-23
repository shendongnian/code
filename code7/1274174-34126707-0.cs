        static void Main(string[] args)
        {
            string xml = @"<Cproducts>   
    <Availability>
            <Departure>
              <Date>2015-12-03T00:00:00.0000000+00:00</Date>
              <Pricing>
                <Price>
                  <Type>ADT</Type>
                  <Value>175.00</Value>
                  <Qty>20</Qty>
                </Price>
                <Price>
                  <Type>CHD</Type>
                  <Value>95.00</Value>
                  <Qty>5</Qty>
                </Price>
                <Price>
                  <Type>INF</Type>
                  <Value>0.00</Value>
                  <Qty>5</Qty>
                </Price>
                <Price>
                  <Type>FAM</Type>
                  <Value>0.00</Value>
                  <Qty>0</Qty>
                </Price>
                <Price>
                  <Type>SEN</Type>
                  <Value>175.00</Value>
                  <Qty>20</Qty>
                </Price>
              </Pricing>
            </Departure>
            <Departure>
              <Date>2015-12-06T00:00:00.0000000+00:00</Date>
              <Pricing>
                <Price>
                  <Type>ADT</Type>
                  <Value>175.00</Value>
                  <Qty>20</Qty>
                </Price>
                <Price>
                  <Type>CHD</Type>
                  <Value>95.00</Value>
                  <Qty>5</Qty>
                </Price>
                <Price>
                  <Type>INF</Type>
                  <Value>0.00</Value>
                  <Qty>5</Qty>
                </Price>
                <Price>
                  <Type>FAM</Type>
                  <Value>0.00</Value>
                  <Qty>0</Qty>
                </Price>
                <Price>
                  <Type>SEN</Type>
                  <Value>175.00</Value>
                  <Qty>20</Qty>
                </Price>
              </Pricing>
            </Departure>
        </Availability>
     </Cproducts>";
            XDocument doc = XDocument.Parse(xml);
            var list = (from element in doc.Elements("Cproducts").Elements("Availability").Elements("Departure")
                        where Convert.ToDateTime(element.Element("Date").Value) < DateTime.Now
                        select element).ToList();
            foreach(XElement el in list)
            {
                Console.WriteLine(el.Element("Date").Value);
            }
        }
