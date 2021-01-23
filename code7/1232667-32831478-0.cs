    public static async Task<T> GetData<T>(string add)
        {
            WebRequest request = WebRequest.Create(add);
            WebResponse response = await request.GetResponseAsync();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                return JsonConvert.DeserializeObject<T>(stream.ReadToEnd());
            }
        }
