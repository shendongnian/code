    public static class RequestExtensions
    {
        public static T ParseRequest<T>(this HttpRequest request)
        {
            request.InputStream.Seek(0, SeekOrigin.Begin);
            using (var inputStream = request.InputStream)
            using (var reader = new StreamReader(inputStream))
            {
                string body = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(body);
            }
        }
    }
