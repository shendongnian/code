        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(me));        
        MemoryStream stream = new MemoryStream();
        jsonSerializer.WriteObject(stream, you);        
        string json = Encoding.Default.GetString(stream.ToArray());
