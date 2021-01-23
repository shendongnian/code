        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        Me[] sizes = new Me[] { new Me{ radius = 34; height = 66; }, new Me { radius = 24; height = 68; } }; // Me DataContract
        DataContractJsonSerializer szr = new DataContractJsonSerializer( typeof(Me[]) );   
        MemoryStream bodyBuffer = new MemoryStream();
        szr.WriteObject( bodyBuffer, sizes );        
        string bodyString = Encoding.Default.GetString(bodyBuffer.ToArray());
        bodyBuffer.Close(); 
        //Response.Write(Server.HtmlEncode(bodyString));
        // REVERSE: the same serializer
        bodyBuffer = new MemoryStream(Encoding.Unicode.GetBytes(bodyString));
        sizes = szr.ReadObject(bodyBuffer) as Me[];
        bodyBuffer.Close(); 
