    class Program
    {
        static void Main(string[] args)
        {
            const string json = "{ " +
                "\"Error\": \"Lol\", " +
                "\"ErrorDate\": \"2016-05-13T10:43:27.6365795Z\", " +
                "\"Application\": \"Business\", " +
                "\"UserName\": \"Josh\", " +
                "\"TraceSession\": \"moo\" " +
            " }";
            var jobj = JObject.Parse(json);
            foreach (var prop in jobj)
            {
                Console.WriteLine("Key: {0}, Value: {1}", prop.Key, prop.Value);
            }
        }
    }
