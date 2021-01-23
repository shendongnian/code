    private TPong ReadDataFromApi<TPing, TPong>(string url, TPing data)
        where TPing : class
        where TPong : class,new() //You need to create instances of TPong
    {
        WebResponse response = Util.SendWebRequest<TPing>(url, data, 30000);
        var res = new TPong(); //Create instance of TPong
        if (response != null)
        {
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();
                res = JsonConvert.DeserializeObject<TPong>(objText);
            }
        }
        return res;
    }
