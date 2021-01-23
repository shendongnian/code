    private class Payload
    {
        public String[] payload;
    }    
    ...
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getMembers(String groupname)
    {
        ...
        Payload p = new Payload();
        // populate
        return new JavaScriptSerializer().Serialize(p); 
    }
