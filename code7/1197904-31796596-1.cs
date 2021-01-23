    private static void _serializeJson<T>(T obj, Stream stream)
    {
        try
        {
            using(var streamWriter = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            using(var jsonWriter = new JsonTextWriter(streamWriter))
            {
                var serializer = new JsonSerializer();
                serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(jsonWriter, obj);
             }
        }
        catch (Exception e)
        {
            //Logger.WriteError(e.ToString());
            Console.WriteLine(e.ToString());
        }
    }
