    try
    { 
        using (HttpWebResponse inboundResponse = (HttpWebResponse)outboundRequest.GetResponse()) //exception here for 502
        using (StreamReader stream = new StreamReader(inboundResponse.GetResponseStream()))
        using (JsonTextReader reader = new JsonTextReader(stream))
        {
            List<T> outputData = new List<T>();
            while (reader.Read())
            {
                JsonSerializer serializer = new JsonSerializer();
                var tempData = serializer.Deserialize<T>(reader);
                outputData.Add(tempData);
            }
            inboundResponse.Close();
            return outputData;
        }
    }
    catch (WebException e)
    {
        if (e.Status == WebExceptionStatus.ProtocolError)
        {
            UIController.addSystemMessageToChat("Protocol Error");
            switch(((HttpWebResponse)e.Response).StatusCode)
            {
                case HttpStatusCode.BadGateway:
                    UIController.addSystemMessageToChat("Resending Response");
                    //process exception
                default:
                    throw;
            }
        }
        
    }
    catch (Exception e)
    {
        // catch and handle an unknown / unexpected exception type
    }
