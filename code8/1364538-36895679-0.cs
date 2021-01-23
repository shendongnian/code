    if (await CreateProfile(demographics).ConfigureAwait(false)) // depending on what dothing is you may not want it here.
    {
        //dothing
    }
    
    private async Task<bool> CreateProfile(Demographics demographics)
    {
        ProfileService profileService = new ProfileService();
    
        CreateProfileBindingModel createProfileBindingModel = this.CreateProfileModel(demographics);
    
        return await profileService.Create(createProfileBindingModel).ConfigureAwait(false);
    }
    
    public async Task<bool> Create(CreateProfileBindingModel model)
    {
        HttpResponseMessage response = await profileServiceRequest.PostCreateProfile(rootURL, model).ConfigureAwait(false);
    
        return response.IsSuccessStatusCode;
    }
    
    public Task<HttpResponseMessage> PostCreateProfile(string url, CreateProfileBindingModel model)
    {
        HttpContent contents = SerialiseModelData(model);
        var resultTask = client.PostAsync(url, contents);
    
        return resultTask;
    }
