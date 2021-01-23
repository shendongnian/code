    public static void SendPushNotification()
    {
        try
        {    
           string applicationID = "AIz..........Fep0";
           string senderId = "30............8";
           string deviceId = "ch_G60NPga4:APA9............T_LH8up40Ghi-J";
           WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
           tRequest.Method = "post";
           tRequest.ContentType = "application/json";
           var data = new
           {
              to = deviceId,
              notification = new
              {
                 body = "Osama",
                 title = "AlBaami",
                 sound = "Enabled"    
              }    
           };      
 
           var serializer = new JavaScriptSerializer();
           var json = serializer.Serialize(data);
           Byte[] byteArray = Encoding.UTF8.GetBytes(json);
           tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
           tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
           tRequest.ContentLength = byteArray.Length; 
           using (Stream dataStream = tRequest.GetRequestStream())
           {
              dataStream.Write(byteArray, 0, byteArray.Length);   
              using (WebResponse tResponse = tRequest.GetResponse())
              {
                 using (Stream dataStreamResponse = tResponse.GetResponseStream())
                 {
                    using (StreamReader tReader = new StreamReader(dataStreamResponse))
                    {
                        String sResponseFromServer = tReader.ReadToEnd();
                        string str = sResponseFromServer;
                    }    
                 }    
              }    
           }    
        }        
        catch (Exception ex)
        {
           string str = ex.Message;
        }          
    }
