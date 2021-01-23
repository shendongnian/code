    namespace RetainBuildIndefinitely
    {
       public class WebApiCalls
       {
          public void RetainBuildIndefinately(string buildId)
          {
             // Max retry attempts
             var retryCount = 30;
    
             // The Tfs Url
             var url = [YourURL eg: http://server:8080/tfs/TeamCollection/Project/_apis/build/builds/{buildId}?api-version=2.0";
    
             // Poll until the build is finished
             // Since this call should be made in the last build step, there shouldn't be too much waiting for this to complete
    
             using (var client = new WebClient {UseDefaultCredentials = true})
             {
                client.Headers.Add("Content-Type", "application/json");
                client.Encoding = Encoding.UTF8;
    
                var completed = false;
                var attempt = 1;
    
                while (completed == false)
                {
                   if (attempt == retryCount)
                   {
                      // Couldn't complete? Clearly something went very wrong
                      // TODO: Sent out a notification email, but to who? 
                      return;
                   }
    
                   var source = client.DownloadString(url);
                   dynamic data = JObject.Parse(source);
    
                   if (data.status == "completed")
                   {
                      // Completed, let's move on!
                      completed = true;
                   }
    
                   attempt = attempt + 1;
    
                   Thread.Sleep(2000);
                }
             }            ;
    
             // Set the keepForever property
             using (var client2 = new WebClient {UseDefaultCredentials = true})
             {
    
                client2.Headers.Add("Content-Type", "application/json");
                client2.Encoding = Encoding.UTF8;
                client2.UploadString(url, "PATCH", "{keepForever : true}");
             }
             
          }
       }
    }
