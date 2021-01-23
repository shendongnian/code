    public static class HttpResponseBaseExtensions
    {
        public static void WriteJson<T>(this HttpResponseBase response, T obj, bool useResponseBuffering = true, bool includeNull = true)
        {
            var contentEncoding = response.ContentEncoding ?? Encoding.UTF8;
            if (!useResponseBuffering)
            {
                response.Buffer = false;
                // use a BufferedStream as suggested in //https://stackoverflow.com/questions/26010915/unbuffered-output-very-slow
                var bufferedStream = new BufferedStream(response.OutputStream, 256 * 1024);
                bufferedStream.WriteJson(obj, contentEncoding, includeNull);
                bufferedStream.Flush();
            }
            else
            {
                response.OutputStream.WriteJson(obj, contentEncoding, includeNull);
            }
        }
        static void WriteJson<T>(this Stream stream, T obj, Encoding contentEncoding, bool includeNull)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] { new StringEnumConverter() },
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,//newly added
                //PreserveReferencesHandling =Newtonsoft.Json.PreserveReferencesHandling.Objects,
                NullValueHandling = includeNull ? NullValueHandling.Include : NullValueHandling.Ignore
            };
            var serializer = JsonSerializer.CreateDefault(settings);
            var textWriter = new StreamWriter(stream, contentEncoding);
            serializer.Serialize(textWriter, obj);
            textWriter.Flush();
        }
    }
