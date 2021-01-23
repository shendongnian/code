            string strXML = @"<Attributes>
                                    <CheckoutAttribute ID=""3"">
                                        <CheckoutAttributeValue>
                                            <Value>dear jason, wishing you a happy easter</Value>
                                        </CheckoutAttributeValue>
                                    </CheckoutAttribute>
                                    <CheckoutAttribute ID=""4"">
                                        <CheckoutAttributeValue>
                                            <Value>Thursday, 31-03-2016</Value>
                                        </CheckoutAttributeValue>
                                    </CheckoutAttribute>
                                </Attributes>";
            byte[] bufAttributes = ASCIIEncoding.UTF8.GetBytes(strXML);
            MemoryStream ms1 = new MemoryStream(bufAttributes);
            // Deserialize to object
            XmlSerializer serializerPlaces = new XmlSerializer(typeof(Attributes));
            try
            {
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    Attributes deserializedXML = (Attributes)serializerPlaces.Deserialize(reader);
                    string Label1Text = (from xmlTag in deserializedXML.CheckoutAttribute where xmlTag.ID == "3" select xmlTag.CheckoutAttributeValue.Value).FirstOrDefault();
                    string Label2Text = (from xmlTag in deserializedXML.CheckoutAttribute where xmlTag.ID == "4" select xmlTag.CheckoutAttributeValue.Value).FirstOrDefault();
                }// put a break point here and mouse-over Label1Text and Label2Text ….
            }
            catch (Exception ex)
            {
                throw;
            }
