    async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        GridViewPostimerkit.ItemsSource = await haePostimerkitPilvestaAsync();
    }
    public static async Task<List<Postimerkit>> haePostimerkitPilvestaAsync()
    {
        Uri address = new Uri("xxx.json"); //public link of our file
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
        WebResponse response = await request.GetResponseAsync();
        Stream stream = response.GetResponseStream();
        string content = ReadStreamAsString(stream);
        return JsonConvert.DeserializeObject(content, typeof(List<Postimerkit>));
    }
    public static string ReadStreamAsString(Stream input)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return Encoding.UTF8.GetString(ms.ToArray(), 0, ms.ToArray().Count());
        }
    }
