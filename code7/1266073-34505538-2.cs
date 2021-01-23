    public void Execute(IServiceProvider serviceProvider)
      {
        IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        IOrganizationServiceFactory serviceFactory;
        IOrganizationService service;
        if (context.Depth > 1)
                return;
        if (context.InputParameters.Contains("Target"))
        {
          //Create Service from Service Factory
         serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
         service = serviceFactory.CreateOrganizationService(context.UserId);
        
         var javaScriptSerializer = new JavaScriptSerializer();
         javaScriptSerializer.MaxJsonLength = 104857600; //200 MB unicode
                StringBuilder URI = new StringBuilder();
                URI.Append(crmRestWebServiceUrl).Append(webServiceMethod);
                //Logger.Info("GetLatestMembershipFromCRMRestWebService is called with Url: " + URI.ToString());
                var request = (HttpWebRequest)WebRequest.Create(URI.ToString());
                request.Method = "POST";
                request.Accept = "application/json";
                request.ContentType = "application/json; charset=utf-8";
                //Serialize request object as JSON and write to request body
                if (latestMembershipRequest != null)
                {
                    var stringBuilder = new StringBuilder();
                    javaScriptSerializer.Serialize(latestMembershipRequest, stringBuilder);
                    var requestBody = stringBuilder.ToString();
                    request.ContentLength = requestBody.Length;
                    var streamWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                    streamWriter.Write(requestBody);
                    streamWriter.Close();
                   // Logger.Info("Request Object that will be sent is: " + stringBuilder.ToString());
                }
               // Logger.Info("Sending Request to CRMRestWebService to get LatestMembership.");
                var response = request.GetResponse();
                //Read JSON response stream and deserialize
                var streamReader = new System.IO.StreamReader(response.GetResponseStream());
                var responseContent = streamReader.ReadToEnd().Trim();
                LatestMembershipResponse latestMembershipResponse = javaScriptSerializer.Deserialize<LatestMembershipResponse>(responseContent);
               // Logger.Info("Latest Membership Reveived is: " + responseContent.ToString() + " has been deserialized Successfully.");
                return latestMembershipResponse;
    }
