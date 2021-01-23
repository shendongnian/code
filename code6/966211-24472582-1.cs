            IPAddress ip = new IPAddress();
            using (StringWriter oStringWriter = new StringWriter())
            {
                using (JsonTextWriter oJsonWriter = new JsonTextWriter(oStringWriter))
                {
                    JsonSerializer oSerializer = null;
                    JsonSerializerSettings oOptions = new JsonSerializerSettings();
                    // Generate the json without quotes around the name objects
                    oJsonWriter.QuoteName = false;
                    // This can be used in order to view the rendered properties "nicely"
                    oJsonWriter.Formatting = Formatting.Indented;
                    oOptions.NullValueHandling = NullValueHandling.Ignore;
                    oSerializer = JsonSerializer.Create(oOptions);
                    oSerializer.Serialize(oJsonWriter, ip);
                    Console.WriteLine(oStringWriter.ToString());
                }
            }
