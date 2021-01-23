    public class CustomWebClient
    {
        public NameValueCollection Headers
        {
            get;
            set;
        }
        public CustomWebClient()
        {
           this.Headers = new NameValueCollection();
        }
        //Overload the constructor based on your requirement.
        public string Post()
        {
          //Perform the post or UploadString with custom logic
        }    
        //Overload the method Post for passing various parameters like the Url(if required)
    }
