    [HttpGet("/")]
    public string Index ([FromUri] MyClass aclass) {
        ...
    }
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://.../");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var url = String.Format("api/ControllerName?ID={0}&Dept={1}", 
            myModel.ID, myModel.Dept);
        HttpResponseMessage response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            MyModel model = await response.Content.ReadAsAsync<MyModel>();
        }
    }
