    using (WebClient client = new WebClient())
    {
        byte[] result = client.UploadValues(url, data);
        File.WriteAllBytes(path, result);
    }
