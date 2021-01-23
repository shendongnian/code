    var data = { 
         UserID: "10", 
         UserName: "Long", 
         AppInstanceID: "100", 
         ProcessGUID: "BF1CC2EB-D9BD-45FD-BF87-939DD8FF9071" 
    };  
    var request = JSON.stringify(data);  
    request = encodeURIComponent(request); 
    
    //call ajax get method 
    ajaxGet:
     ...
     url: "/ProductWebApi/api/Workflow/StartProcess?data=", 
     data: request,
     ...
    [HttpGet]  
    public ResponseResult StartProcess()  
    {  
        dynamic queryJson = ParseHttpGetJson(Request.RequestUri.Query);  
        //begin to parse...
        int appInstanceID = int.Parse(queryJson.AppInstanceID.Value);  
        Guid processGUID = Guid.Parse(queryJson.ProcessGUID.Value);  
        int userID = int.Parse(queryJson.UserID.Value);  
        string userName = queryJson.UserName.Value;  
        ...
    } 
    private dynamic ParseHttpGetJson(string query)  
    {  
        if (!string.IsNullOrEmpty(query))  
        {  
            try  
            {  
                var json = query.Substring(7, query.Length - 7);  // the number 7 is for data=
                json = System.Web.HttpUtility.UrlDecode(json);  
                dynamic queryJson = JsonConvert.DeserializeObject<dynamic>(json);  
      
                return queryJson;  
            }  
            catch (System.Exception e)  
            {  
                throw new ApplicationException("wrong json format in the query string！", e);  
            }  
        }  
        else  
        {  
            return null;  
        }  
    }  
