        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        Me theBody = new Me() { radius = 14; height = 66; } //Me [Serializable]
        MemoryStream bodyBuffer = new MemoryStream();
        DataContractJsonSerializer szr
           = new DataContractJsonSerializer(typeof(Me));   
        szr.WriteObject(bodyBuffer, theBody);        
        string bodyString = Encoding.Default.GetString(bodyBuffer.ToArray());
        bodyBuffer.Close(); 
        //Response.Write(Server.HtmlEncode(bodyString));
        // REVERSE: the same serializer
        bodyBuffer = new MemoryStream(Encoding.Unicode.GetBytes(bodyString));
        theBody = szr.ReadObject(bodyBuffer) as Me;
        bodyBuffer.Close(); 
