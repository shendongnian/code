    private static HelpPageApiModel GenerateApiModel(ApiDescription apiDescription, HttpConfiguration config)
    {
        HelpPageApiModel apiModel = new HelpPageApiModel()
        {
            ApiDescription = apiDescription,
        };
        ModelDescriptionGenerator modelGenerator = config.GetModelDescriptionGenerator();
        HelpPageSampleGenerator sampleGenerator = config.GetHelpPageSampleGenerator();
        GenerateUriParameters(apiModel, modelGenerator);
        GenerateRequestModelDescription(apiModel, modelGenerator, sampleGenerator);
        GenerateResourceDescription(apiModel, modelGenerator);
        GenerateSamples(apiModel, sampleGenerator);
        //This will remove request body parameters from your Api Help Page matching 'IsRejected'
        var isRejectedParameter = apiModel.RequestBodyParameters.SingleOrDefault(x => x.Name == "IsRejected");
        if (isRejectedParameter != null)
            apiModel.RequestBodyParameters.Remove(isRejectedParameter);
        //This will remove elements with 'IsRejected' for the Help Page sample requests 
        var sampleRequests = new Dictionary<MediaTypeHeaderValue, object>();
        foreach (var kvp in apiModel.SampleRequests)
        {
            //1.) iterate through each object in SampleRequests dictionary.
            //2.) modify the json or xml to remove the "IsRejected" elements
            //3.) assign modified results to a new dictionary
            //4.) change the HelpPageApiModel. SampleRequests setter to be not private
            //5.) assign new dictionary to HelpPageApiModel.SampleRequests
            if (Equals(kvp.Key, new MediaTypeHeaderValue("application/json")))
            {
                var jObject = JObject.Parse(kvp.Value.ToString());
                jObject.Remove("IsRejected");
                sampleRequests.Add(new MediaTypeHeaderValue("application/Json"), jObject.ToString());
            }
            else if(Equals(kvp.Key, new MediaTypeHeaderValue("text/json")))
            {
                //do stuff
            }
            else if (Equals(kvp.Key, new MediaTypeHeaderValue("application/xml")))
            {
                //do stuff
            }
            else if (Equals(kvp.Key, new MediaTypeHeaderValue("text/xml")))
            {
                //do stuff
            }
            else
            {
                //form urlencoded or others
                sampleRequests.Add(kvp.Key,kvp.Value);
            }
        }
        apiModel.SampleRequests = sampleRequests;
        return apiModel;
    }
