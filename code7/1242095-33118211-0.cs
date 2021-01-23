    public class savetodbsingle 
    {
        private Action<object, Exception> _callback;
        public static  string  insert(string id, string type, string cat, Action<object,Exception> callback)
        {
            Uri uri = new Uri("http://yxz.com");
                
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.UploadStringCompleted += wc_UploadComplete6;
            _callback = callback;
            wc.UploadStringAsync(uri, "POST", json);
        
        }
        private static void wc_UploadComplete6(object sender, UploadStringCompletedEventArgs e)
        {
            //Saving to database logic here 
            
            // When done, you can return something if needed
            // or return an exception when something bad happened.
            _callback(someObject, someException)
        }
    }
