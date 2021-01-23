    public static async Task DoSomethingAsync()
    {
        try
        {
            using (var client = new HttpClient())
            {
                var url = "http://10.0.0.68/SET Initialization";
                var url2 = "http://10.0.0.68/GET Status";
                var response = await client.GetAsync(url);
                Debug.WriteLine(response);
                response = await client.GetAsync(url2);
                Debug.WriteLine(response);
                var result = await response.Content.ReadAsStringAsync();
                var jsonString = result.Substring(4);
                var serializer = new DataContractJsonSerializer(typeof(MediaStatus));
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                var data = (MediaStatus)serializer.ReadObject(ms);
                Debug.Write(data.ProgNo);
            }
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception.Message, exception.Source);
        }
    }
