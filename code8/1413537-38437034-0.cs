     string _MessageIn="<?Label TSRAY|RESERVATION|317859|SUCCESS?>    <Reservation xmlns='reservation.fidelio.2.0' mfShareAction='NA' mfReservationAction='EDIT'>      <HotelReference>        <hotelCode>TSRAY</hotelCode>      </HotelReference>     <confirmationID>Y6Z7TFJDK</confirmationID>      <reservationID>347557</reservationID>      <reservationOriginatorCode>JA</reservationOriginatorCode>      <originalBookingDate>2010-08-16T22:53:23.000</originalBookingDate>      <StayDateRange timeUnitType='DAY'>        <startTime>2010-08-19T00:00:00.000</startTime>        <numberOfTimeUnits>3</numberOfTimeUnits>      </StayDateRange>      <GuestCounts>        <GuestCount>          <ageQualifyingCode>ADULT</ageQualifyingCode>          <mfCount>2</mfCount>        </GuestCount>        <GuestCount>          <ageQualifyingCode>CHILD</ageQualifyingCode>          <mfCount>0</mfCount>        </GuestCount>      </GuestCounts>      ...................   ..................    </Reservation>";    
                    string HotelCode = ""; // you can create HotelCode-Array to store all Hotelcodes
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(_MessageIn);
                    XmlNodeList list=doc.GetElementsByTagName("hotelCode");
                    foreach (XmlNode node in list)
                    {
                        if (node.Name == "hotelCode")
                        {
                            HotelCode=node.InnerText;
                        }
                    }
