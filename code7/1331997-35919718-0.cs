    static void Main(string[] args)
    {
      HttpWebRequest request; 
      HttpWebResponse response = null; 
      StreamReader reader; 
      StringBuilder sbSource; 
      // 1. Set some variables specific to your account.
      string uri = "https://yoursubdomain.harvestapp.com/projects";
      string username="youremail@somewhere.com";
      string password="yourharvestpassword";
      string usernamePassword = username + ":" + password;
      ServicePointManager.ServerCertificateValidationCallback = Validator;
    try
      { 
         request = WebRequest.Create(uri) as HttpWebRequest; 
         request.MaximumAutomaticRedirections = 1;
         request.AllowAutoRedirect = true;
         // 2. It's important that both the Accept and ContentType headers are
         // set in order for this to be interpreted as an API request.
         request.Accept = "application/xml"; 
         request.ContentType = "application/xml"; 
         request.UserAgent = "harvest_api_sample.cs";
         // 3. Add the Basic Authentication header with username/password string.
         request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
         using (response = request.GetResponse() as HttpWebResponse) 
         { 
            if (request.HaveResponse == true && response != null) 
            { 
               reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
               sbSource = new StringBuilder(reader.ReadToEnd());
               // 4. Print out the XML of all projects for this account.
               Console.WriteLine(sbSource.ToString()); 
            } 
         } 
      } 
