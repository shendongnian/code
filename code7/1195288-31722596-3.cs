     public JsonResponse ServiceCall(Stream dataStream, object parameter) {
         var dataBytes = dataStream.ReadToEnd();
         // use the required encoding to get the string data
         var dataString = Encoding.UTF8.GetString(dataBytes);
         var dataJson = default(EndSessionRequest);
         try { dataJson = new JavaScriptSerializer().Deserialize<EndSessionRequest>(); }
         catch {  
             // the request includes just one entry that's why
             // the serializer fails getting the object so
             // you could continue like..
             dataJson = new JavaScriptSerializer().Deserialize<EndSessionRequestWithSingleCounter>();
         }
         // handle request ...
     }
