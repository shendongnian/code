        using System.Runtime.Serialization.Json;  //System.ServiceModel.Web
        Me[] sizes = new Me[] { new Me{ radius = 34, height = 66 }, new Me{ radius = 24, height = 68 } }; // Me [DataContract]
        DataContractJsonSerializer szr = new DataContractJsonSerializer( typeof(Me[]) );   
        MemoryStream toJSONBuf= new MemoryStream();
        szr.WriteObject( toJSONBuf, sizes );        
        string strJSON = Encoding.Default.GetString(toJSONBuf.ToArray());
        toJSONBuf.Close(); 
        //Response.Write(Server.HtmlEncode( strJSON ));
        // REVERSE: the same serializer
        toJSONBuf= new MemoryStream(Encoding.Unicode.GetBytes( strJSON ));
        sizes = szr.ReadObject(toJSONBuf) as Me[];
        toJSONBuf.Close(); 
