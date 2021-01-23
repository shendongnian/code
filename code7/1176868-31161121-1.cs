    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)] //Add this
    public string AddToPrintQueue(string buttonID)
    {
         try
         {
               //Your other code
         }
         catch
         {
              return "There was an issue, we appologize for the inconvenience";
         }
    
         return "Added to print queue";
    }
