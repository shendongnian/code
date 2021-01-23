            var tracey = new TraceyData();
            tracey.TraceID = Guid.NewGuid().ToString();
            tracey.SessionID = "5";
            tracey.Tags["Referrer"] = "http://www.sky.net/deals";
            tracey.Stuff = new string[] { "Alpha", "Bravo", "Charlie" };
            tracey.Application = "Responsive";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore; 
            
            using (var sw = new StringWriter())
            {
                using (var jsonWriter = new TsonTextWriter(sw))
                {
                    JsonSerializer.CreateDefault(settings).Serialize(jsonWriter, tracey);
                }
                Debug.WriteLine(sw.ToString());
            }
