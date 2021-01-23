    ResponseDeactivated o = new ResponseDeactivated();
    o.Add("123456789");
    o.Add("ABCDEFGHI");
    DataContractSerializer serializer = new DataContractSerializer(typeof(ResponseDeactivated));            
    
    serializer.WriteObject(stream, o);
