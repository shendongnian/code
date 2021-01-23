      string testXMLData = @"<AgentBookingStatusResponse><Eta>2012-11-19T15:40:15.0819269+00:00</Eta></AgentBookingStatusResponse>";  
      
      //First we convert this XML to JSON
      var doc = new XmlDocument();
      doc.LoadXml(testXMLData);
      string jsonText = JsonConvert.SerializeXmlNode(doc);
      //Then we use JObject to parse the converted JSON data to an Object
      JObject jsonDataObj = JObject.Parse(jsonText);
      //Grab Token "Eta" and convert to DateTime Object
      var token = jsonDataObj.SelectToken("AgentBookingStatusResponse.Eta").ToString();
      var dateTimeToken = Convert.ToDateTime(token);
     
      //DateTime Object to a string with UK Culture information and proper Formatting
      var ukDateTime = dateTimeToken.ToString("O", CultureInfo.GetCultureInfo("en-GB"));
