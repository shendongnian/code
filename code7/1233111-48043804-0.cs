    public async Task<MyCustomClass> MethodUnderTest()
    {
        // ...
    
        using (var client = new HttpClient(...))
        {
            // ...
    
            var json = response.Content.ReadAsStringAsync();
            return JsonConvert.Deserialize<MyCustomClass>(json);
        }
    }
