        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(me));        
        //manifest-->
        MemoryStream stream = new MemoryStream();
        jsonSerializer.WriteObject(stream, you);        
        string sj = Encoding.Default.GetString(stream.ToArray());
        stream.Close(); Response.Write(Server.HtmlEncode(sj));
