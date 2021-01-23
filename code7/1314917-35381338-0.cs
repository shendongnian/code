    FiddlerApplication.ResponseHeadersAvailable += FProjectStatics.OnAfterSessionComplete;
    FiddlerAppication.BeforeResponse += FProjectStatics.OnBeforeResponse ;
    public static void OnBeforeResponse( Session s ){
       string sContentType = oS.oResponse.MIMEType;
       if (sContentType.OICStartsWithAny("text/event-stream", "multipart/x-mixed-replace",
       "video/", "audio/", "application/x-mms-framed"))
         {
           oS.bBufferResponse = false;
         }
    
    public static void OnAfterSessionComplete( Session s ){
       string sContentType = oS.oResponse.MIMEType;
       if (sContentType.OICStartsWithAny("text/event-stream", "multipart/x-mixed-replace",
       "video/", "audio/", "application/x-mms-framed"))
         {
           Console.WriteLine(s.ResponseHeaders) ;
         }
    
    }
