        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        Me me = new Me() { radius = 14; height = 66; } //Me [Serializable]
        MemoryStream meToJSON = new MemoryStream();
        DataContractJsonSerializer jsonSerializer 
           = new DataContractJsonSerializer(typeof(Me));   
        jsonSerializer.WriteObject(meToJSON, me);        
        string meStringified = Encoding.Default.GetString(meToJSON.ToArray());
        //Response.Write(Server.HtmlEncode(meStringified));
        meToJSON.Close(); 
        // REVERSE: using the same serializer extension
        meToJSON = new MemoryStream(Encoding.Unicode.GetBytes(meStringified));
        DataContractJsonSerializer deSerializer 
           = new DataContractJsonSerializer(typeof(Me)); 
        Me backToMe = deSerializer.ReadObject(meToJSON) as Me;
        meToJSON.Close(); 
