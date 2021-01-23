        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(me));        
        //manifest-->
        MemoryStream stream = new MemoryStream();
        jsonSerializer.WriteObject(stream, you);        
        //string sj = Encoding.Default.GetString(stream.ToArray());
        //Response.Write(Server.HtmlEncode(sj));
        //stream.Close(); 
        //Deserialize
        jsonSerializer = new DataContractJsonSerializer(typeof(me)); 
        me you = jsonSerializer.ReadObject(stream) as me;
        stream.Close(); 
