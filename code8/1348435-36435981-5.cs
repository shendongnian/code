        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        DataContractJsonSerializer jsonSerializer = 
        new DataContractJsonSerializer(typeof(Me));   
        MemoryStream stream = new MemoryStream();
        Me me = new Me() { radius = 28; height = 72; }     
        jsonSerializer.WriteObject(stream, me);        
        string jstring = Encoding.Default.GetString(stream.ToArray());
        //Response.Write(Server.HtmlEncode(jstring));
        stream.Close(); 
        // REVERSE: using the same serializer extension
        DataContractJsonSerializer deSerializer = new DataContractJsonSerializer(typeof(Me)); 
        stream = new MemoryStream(Encoding.Unicode.GetBytes(jstring));
        Me sameMe = deSerializer.ReadObject(stream) as Me;
        stream.Close(); 
