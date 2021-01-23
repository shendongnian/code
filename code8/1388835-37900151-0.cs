    //DON'T USE ASYNC/AWAIT WITH VOID NO NO NO NO NO NO
    //USE TASK
    public async Task GetCategoryList() {
        try {
            AuthenticationResult result = authContext.AcquireToken(AppServiceResourceId, clientId, redirectUri, PromptBehavior.Never);
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
            //make call to web api and get response
            var response = await httpClient.GetAsync(AppServiceBaseAddress + "/api/CategoriesWebApi");
            //check to make sure there is something to read
            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength.GetValueOrDefault() > 0) {
                var jsonString = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<Model.Category>>(jsonString);
                //check to make sure model was deserialized properly and has items
                if(model != null && model.Count > 0) {
                    //shouldn't clear till you have something to replace it with
                    Categories.Clear();
                    foreach (var cat in model) {
                        var currentCategory = new Category();
                        currentCategory.CategoryID = cat.CategoryID;
                        currentCategory.Description = cat.Description;
                        foreach (var item in cat.AssignedCIs) {
                            currentCategory.AssignedCIs.Add(item);
                        }
                        Categories.Add(currentCategory);
                    }
                }
            } 
        } catch { //Notify User/UI of error }
    }
