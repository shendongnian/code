            request.ContentType = "application/json";
            request.Method = action;
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new UnderscoreMappingResolver(),
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                Converters =
                    {
                        new IsoDateTimeConverter
                        {
                            DateTimeStyles = DateTimeStyles.RoundtripKind
                        },
                        new StringEnumConverter
                        {
                            CamelCaseText = true
                        }
                    }
            };
            var json = JsonConvert.SerializeObject(payload, serializerSettings);
            request.ContentLength = json.Length;
            Console.Out.Write(request.RequestUri);
            using (var stream = request.GetRequestStream())
            {
                using (var sw = new StreamWriter(stream))
                {
                    sw.Write(json);
                }
            }
            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }
