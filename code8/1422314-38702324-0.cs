    public static class HttpResponseBaseExtensions
    {
        public static void WriteJson<T>(this HttpResponseBase response, T obj, bool useResponseBuffering = true, bool includeNull = true)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] { new StringEnumConverter() },
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,//newly added
                //PreserveReferencesHandling =Newtonsoft.Json.PreserveReferencesHandling.Objects,
                NullValueHandling = includeNull ? NullValueHandling.Include : NullValueHandling.Ignore
            };
            var contentEncoding = response.ContentEncoding ?? Encoding.UTF8;
            var serializer = JsonSerializer.CreateDefault(settings);
            if (!useResponseBuffering)
            {
                response.Buffer = false;
                // use a BufferedStream as suggested in //https://stackoverflow.com/questions/26010915/unbuffered-output-very-slow
                var bufferedStream = new BufferedStream(response.OutputStream, 256 * 1024);
                var textWriter = new StreamWriter(bufferedStream, contentEncoding);
                serializer.Serialize(textWriter, obj);
                textWriter.Flush();
                bufferedStream.Flush();
            }
            else
            {
                var textWriter = new StreamWriter(response.OutputStream, contentEncoding);
                serializer.Serialize(textWriter, obj);
                textWriter.Flush();
            }
        }
    }
