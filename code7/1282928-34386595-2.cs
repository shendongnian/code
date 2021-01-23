    dynamic deserializedJson = JsonConvert.DeserializeObject(yourJson);
    foreach(dynamic car in deserializedJson.cars.car)
    {
        string url = car.image.thumb.url;
        string img = url.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[1];
        
        using (WebClient client = new WebClient()) 
        {
            client.DownloadFile(url, img); 
        }
    }
