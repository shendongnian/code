    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("file.json"))
        {
            string json = r.ReadToEnd();
            RootObject company = JsonConvert.DeserializeObject<RootObject>(json);
       }
    }
