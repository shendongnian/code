    using (var client = new HttpClient())
    {
        // New code:
        client.BaseAddress = new Uri("http://localhost/QAQC_SyncWebService/Tasks/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var infoToSend = "1234";
    var response = await client.PostAsJsonAsync("UpdateTasks", infoToSend);
    }
