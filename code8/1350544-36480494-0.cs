        private static async Task<JObject> ProcessJsonResponse(HttpResponseMessage response)
        {
            // Open the stream the stream from the network
            using (var s = await ProcessResponseStream(response).ConfigureAwait(false))
            {
                using (var sr = new StreamReader(s))
                {
                    using (var reader = new JsonTextReader(sr))
                    {
                        var serializer = new JsonSerializer {DateParseHandling = DateParseHandling.None};
                        return serializer.Deserialize<JObject>(reader);
                    }
                }
            }
        }
