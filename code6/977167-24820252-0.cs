    var list = JsonConvert.DeserializeObject<List<object>>(serial,
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });
