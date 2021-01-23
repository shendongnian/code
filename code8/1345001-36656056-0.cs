       string RequestContent = "";
    
      RequestContent = Extract_Json_From_Request(actionContext.Request.Content);
    
      private string Extract_Json_From_Request(HttpContent Requestcontent) 
            {
                string RequestBody = "";
    
                try
                {
                    var content = Requestcontent.ReadAsStringAsync().Result;
                    RequestBody = content.ToString();
                }
                catch (Exception ex)
                {
                    RequestBody = ex.Message;
    
                }
                return RequestBody;
            
            }
