    if (response.IsSuccessStatusCode)
    {
        return await response.Content.ReadAsAsync<T>();
    }
    else
    {
        var httpErrorObject = await response.Content.ReadAsStringAsync();
        var anonymousErrorObject =
            new { message = "", ModelState = new Dictionary<string, string[]>() };
    
        // Deserialize:
        var deserializedErrorObject =
            JsonConvert.DeserializeAnonymousType(httpErrorObject, anonymousErrorObject);
    
        // Check if there are actually model errors
        if (deserializedErrorObject.ModelState != null)
        {
            var errors =
                deserializedErrorObject.ModelState
                                        .Select(kvp => string.Join(". ", kvp.Value));
            for (int i = 0; i < errors.Count(); i++)
            {
                // Add errors to ModelState in Asp.net mvc app
    
            }
        }
        // Othertimes, there may not be Model Errors:
        else
        {
            var error =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(httpErrorObject);
            foreach (var kvp in error)
            {
                // Now this is not model error so you can throw exception 
                // or any custom action what ever you like
            }
        }
    }
