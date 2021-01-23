    if(!response.IsSuccessStatusCode)
    {
        var errors = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
        var message = errors[HttpErrorKeys.MessageKey];
        // message is "Something bad happened"
    }
