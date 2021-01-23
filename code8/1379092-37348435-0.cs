    private TPong ReadDataFromApi<TPong, TPing>(string url, TPing data)  TPong : class, new() where TPing : class
    {
        string url = "URL_TO_HIT";
        WebResponse response = Util.SendWebRequest<TPing>(url, data, 30000);
        var res = new TPong(); // USE TPong HERE
        if (response != null)
        {
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();
                res = JsonConvert.DeserializeObject<TPong>(objText); // AND HERE
            }
        }
        return res;
    }
