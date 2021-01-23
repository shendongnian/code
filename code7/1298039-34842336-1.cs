            if (!Directory.Exists(Global.DataDirectory))
                Directory.CreateDirectory(Global.DataDirectory);
            var serializerSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Auto, ContractResolver = jsonResolver };
            serializerSettings.Converters.Add(new KeyedIListMergeConverter(settings.ContractResolver));
            JsonConvert.PopulateObject(File.ReadAllText(Path.Combine(Global.DataDirectory, fileName + ".json")), settingGroup, serializerSettings);
