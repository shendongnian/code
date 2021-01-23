            string strXML = @"<Availability>
                <RecommendedSegment>
                    <Duration>1720</Duration>
                    <FareBasis>Y77OW</FareBasis>
                    <FlightSegment>
                        <DepDate>11 August</DepDate>
                        <DepTime>0830</DepTime>
                        <ArrDate>11 August</ArrDate>
                        <ArrTime>1110</ArrTime>
                        <DepDay>Mon</DepDay>
                        <ArrDay>Mon</ArrDay>
                        <DepAirport>LHR</DepAirport>
                        <DepAirportName>Heathrow</DepAirportName>
                        <DepCityName>London</DepCityName>
                        <ArrAirport>FRA</ArrAirport>
                        <ArrAirportName>Frankfurt Int'l</ArrAirportName>
                        <ArrCityName>Frankfurt</ArrCityName>
                        <DepCountry>United Kingdom</DepCountry>
                        <ArrCountry>Germany</ArrCountry>
                        <Airline>LH</Airline>
                        <AirName>Lufthansa</AirName>
                        <FlightNo>925</FlightNo>
                        <BookingClass>Y</BookingClass>
                        <AirCraftType>32A</AirCraftType>
                        <ETicket>Y</ETicket>
                        <NonStop>0</NonStop>
                        <DepTer>1</DepTer>
                        <ArrTer>1</ArrTer>
                        <AdtFareBasis>Y77OW</AdtFareBasis>
                        <ChdFareBasis>
                        </ChdFareBasis>
                        <InfFareBasis>
                        </InfFareBasis>
                    </FlightSegment>
                    <FlightSegment>
                        <DepDate>11 August</DepDate>
                        <DepTime>1330</DepTime>
                        <ArrDate>12 August</ArrDate>
                        <ArrTime>0100</ArrTime>
                        <DepDay>Mon</DepDay>
                        <ArrDay>Tue</ArrDay>
                        <DepAirport>FRA</DepAirport>
                        <DepAirportName>Frankfurt Int'l</DepAirportName>
                        <DepCityName>Frankfurt</DepCityName>
                        <ArrAirport>BOM</ArrAirport>
                        <ArrAirportName>Bombay</ArrAirportName>
                        <ArrCityName>Mumbai</ArrCityName>
                        <DepCountry>Germany</DepCountry>
                        <ArrCountry>India</ArrCountry>
                        <Airline>LH</Airline>
                        <AirName>Lufthansa</AirName>
                        <FlightNo>756</FlightNo>
                        <BookingClass>Y</BookingClass>
                        <AirCraftType>744</AirCraftType>
                        <ETicket>Y</ETicket>
                        <NonStop>0</NonStop>
                        <DepTer>1</DepTer>
                        <ArrTer>2</ArrTer>
                        <AdtFareBasis>Y77OW</AdtFareBasis>
                        <ChdFareBasis>
                        </ChdFareBasis>
                        <InfFareBasis>
                        </InfFareBasis>
                    </FlightSegment>
                    <FlightSegment>
                        <DepDate>12 August</DepDate>
                        <DepTime>0515</DepTime>
                        <ArrDate>12 August</ArrDate>
                        <ArrTime>0620</ArrTime>
                        <DepDay>Tue</DepDay>
                        <ArrDay>Tue</ArrDay>
                        <DepAirport>BOM</DepAirport>
                        <DepAirportName>Bombay</DepAirportName>
                        <DepCityName>Mumbai</DepCityName>
                        <ArrAirport>GOI</ArrAirport>
                        <ArrAirportName>Dabolim</ArrAirportName>
                        <ArrCityName>Goa</ArrCityName>
                        <DepCountry>India</DepCountry>
                        <ArrCountry>India</ArrCountry>
                        <Airline>AI</Airline>
                        <AirName>Air India</AirName>
                        <FlightNo>984</FlightNo>
                        <BookingClass>Y</BookingClass>
                        <AirCraftType>321</AirCraftType>
                        <ETicket>Y</ETicket>
                        <NonStop>0</NonStop>
                        <DepTer>2</DepTer>
                        <ArrTer>
                        </ArrTer>
                        <AdtFareBasis>Y</AdtFareBasis>
                        <ChdFareBasis>
                        </ChdFareBasis>
                        <InfFareBasis>
                        </InfFareBasis>
                    </FlightSegment>
                    <DepAirport>LHR</DepAirport>
                    <DepCity>LON</DepCity>
                    <DepCountry>GB</DepCountry>
                    <DepZone>1</DepZone>
                    <ArrAirport>GOI</ArrAirport>
                    <ArrCity>GOI</ArrCity>
                    <ArrCountry>IN</ArrCountry>
                    <ArrZone>5</ArrZone>
                </RecommendedSegment>
            </Availability>";
            byte[] bufXML = ASCIIEncoding.UTF8.GetBytes(strXML);
            MemoryStream ms1 = new MemoryStream(bufXML);
            // Deserialize to object
            XmlSerializer serializer = new XmlSerializer(typeof(Availability));
            try
            {
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    Availability deserializedXML = (Availability)serializer.Deserialize(reader);
                }// put a break point here and mouse-over Label1Text and Label2Text ….
            }
            catch (Exception ex)
            {
                throw;
            }
