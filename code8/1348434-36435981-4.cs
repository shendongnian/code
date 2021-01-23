        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Me));        
        MemoryStream stream = new MemoryStream();
        jsonSerializer.WriteObject(stream, you);        
        string sj = Encoding.Default.GetString(stream.ToArray());
        //Response.Write(Server.HtmlEncode(sj));
        stream.Close(); 
        // REVERSE: using the same serializer extension
        DataContractJsonSerializer deSerializer = new DataContractJsonSerializer(typeof(me)); 
        stream = new MemoryStream(Encoding.Unicode.GetBytes(sj));
        Me you = deSerializer.ReadObject(stream) as Me;
        stream.Close(); 
