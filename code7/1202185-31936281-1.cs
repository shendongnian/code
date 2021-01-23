    string URL = "https://secure.lni.wa.gov/verify/Controller.aspx/GetBusinessDetails";
    using (var client = new WebClient())
    {
        client.Headers["Content-Type"] = "application/json; charset=UTF-8";
        var json =  client.UploadString(URL, JsonConvert.SerializeObject(new { License = "1CALLCC871KC", Ubi ="", IrlVilationId="", IsSecured="" }));
        dynamic response = JsonConvert.DeserializeObject(json);
        Console.WriteLine(response.d.ReturnValue.Contractor.BusinessName.ToString());
    }
