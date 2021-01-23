            var settings = new JsonSerializerSettings();
            settings.Converters.Add(converter);
            var serializer = JsonSerializer.Create(settings);
            var query = from obj in JsonConvert.DeserializeObject<List<JObject>>(jsonList, settings)
                        let jType = obj["Type"]
                        where jType != null
                        let type = Type.GetType(string.Format("WCFService.{0}", (string)jType))
                        where type != null
                        where obj.Remove("Type") // Assuming this is a synthetic property added during serialization that you want to remove.
                        select obj.ToObject(type, serializer);
            var objs = query.ToList();
