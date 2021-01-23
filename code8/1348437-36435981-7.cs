        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        Me me = new Me() { radius = 28; height = 72; }     
        MemoryStream meToJSON = new MemoryStream();
        DataContractJsonSerializer jsonSerializer 
           = new DataContractJsonSerializer(typeof(Me));   
        jsonSerializer.WriteObject(meToJSON, me);        
        string meStringified = Encoding.Default.GetString(meToJSON.ToArray());
        //Response.Write(Server.HtmlEncode(meStringified));
        meToJSON.Close(); 
        // REVERSE: using the same serializer extension
        DataContractJsonSerializer deSerializer 
           = new DataContractJsonSerializer(typeof(Me)); 
        meToJSON = new MemoryStream(Encoding.Unicode.GetBytes(meStringified));
        Me backToMe = deSerializer.ReadObject(meToJSON) as Me;
        meToJSON.Close(); 
