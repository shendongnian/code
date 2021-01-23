    static void Main(string[] args)
    {
        using (var wc = new WebClient())
        {
            var stream = wc.DownloadData("http://api.aerisapi.com/observations/milwaukee,wi?client_id=xxx&client_secret=xxx");
            dynamic jsonObject = Parse(stream);
            Console.WriteLine(jsonObject.success);
            Console.WriteLine(jsonObject.error);
            Console.WriteLine(jsonObject.response);
            Console.WriteLine(jsonObject.response.place.name);
        }
        Console.ReadLine();
    }
    public static JObject Parse(byte[] stream)
    {
        var jsonStr = Encoding.UTF8.GetString(stream);
        return JObject.Parse(jsonStr);
    }
