    HttpContent c = new StringContent("1234");
    HttpClient client = new HttpClient();
    c.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    client.BaseAddress = new Uri("http://localhost/QAQC_SyncWebService/Tasks/UpdateTasks");
    var resp = client.PutAsync(client.BaseAddress, c).Result;
