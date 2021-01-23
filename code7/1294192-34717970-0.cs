    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string  FunctiGetJsononName(string str){
    
        Context.Response.Clear();
        Context.Response.ContentType = "application/json"; 
    ........
    }
