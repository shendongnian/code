    // We need these for the method below
    using Google.Apis.Script.v1;
    using Google.Apis.Script.v1.Data;
    
    ...    
    public static bool copyWorksheet(ScriptService scriptService, string destinationSpreadsheetId, string destinationWorksheetTitle, string originSpreadsheetId, string originWorksheetTitle)
      {
        // You can get the script ID by going to the script in the 
        // Google Apps Scripts Editor > Publish > Deploy as API executable... > API ID
        string scriptId = "your-apps-script-id";
    
        ExecutionRequest request = new ExecutionRequest();
        request.Function = "copyWorksheet";
        IList<object> parameters = new List<object>();
             
        parameters.Add(destinationSpreadsheetId);
        parameters.Add(destinationWorksheetTitle);
        parameters.Add(originSpreadsheetId);
        parameters.Add(originWorksheetTitle);            
        
        request.Parameters = parameters;
                
        ScriptsResource.RunRequest runReq = scriptService.Scripts.Run(request, scriptId);
    
        try
        {
          Operation op = runReq.Execute();
    
          if (op.Error != null)
          {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " The Apps script encountered an error");
            // The API executed, but the script returned an error.
            
            IDictionary<string, object> error = op.Error.Details[0];
            Console.WriteLine( "Script error message: {0}", error["errorMessage"]);
            if ( error.ContainsKey("scriptStackTraceElements") )
            {
                            
              // There may not be a stacktrace if the script didn't
              // start executing.
              Console.WriteLine("Script error stacktrace:");
              Newtonsoft.Json.Linq.JArray st = (Newtonsoft.Json.Linq.JArray)error["scriptStackTraceElements"];
              foreach (var trace in st)
                {
                  Console.WriteLine(
                    "\t{0}: {1}",
                    trace["function"],
                    trace["lineNumber"]);
                }
                          
              }
            }
            else
            {
              // The result provided by the API needs to be cast into
              // the correct type, based upon what types the Apps
              // Script function returns. Here, the function returns
              // an Apps Script Object with String keys and values.
              // It is most convenient to cast the return value as a JSON
              // JObject (folderSet).
    
              return true;
                
            }
          }
          catch (Google.GoogleApiException e)
          {
            // The API encountered a problem before the script
            // started executing.
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " Could not call Apps Script");
          }
    
          return false;
        }
    
    ...
