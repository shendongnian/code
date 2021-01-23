    var person = new {
             id= "123",
             name= "Jhon",
             surname= "Tiger",
             birthdate= "7.2.1949"
         }
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("JSONHandler");
        var result = client.PostAsJsonAsync("/mymethod", person).Result;
        switch (result.StatusCode)
        {
            case HttpStatusCode.OK:
                Trace.TraceInformation("Updated ok");
                break;
            default:
                Trace.TraceError("Something went wrong");
                break;
        }
    }
