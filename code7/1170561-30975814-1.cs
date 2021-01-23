    public class SaveRecordHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //  Read in a JSON record which has been POSTED to a webpage, 
            //  and turn it back into an object.  
            string jsonString = "";
            HttpContext.Current.Request.InputStream.Position = 0;
            using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
            {
                jsonString = inputStream.ReadToEnd();
            }
    
            YourDataClass oneQuestion = JsonConvert.DeserializeObject<YourDataClass>(jsonString);
