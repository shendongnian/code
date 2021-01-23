        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        DataContractJsonSerializer jsonSerializer 
        = new DataContractJsonSerializer(typeof(Me));   
        MemoryStream meToStream = new MemoryStream();
        Me me = new Me() { radius = 28; height = 72; }     
        jsonSerializer.WriteObject(meToStream, me);        
        string meInJStr = Encoding.Default.GetString(meToStream.ToArray());
        //Response.Write(Server.HtmlEncode(meInJStr));
        meToStream.Close(); 
        // REVERSE: using the same serializer extension
        DataContractJsonSerializer deSerializer 
        = new DataContractJsonSerializer(typeof(Me)); 
        meToStream = new MemoryStream(Encoding.Unicode.GetBytes(meInJStr));
        Me backToMe = deSerializer.ReadObject(meToStream) as Me;
        meToStream.Close(); 
