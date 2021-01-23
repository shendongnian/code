            var test = new MediaInfo { MediaPanel = "panel" };
            var settings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { IgnoreSerializableAttribute = false } };
            var json = JsonConvert.SerializeObject(test, settings);
            Console.WriteLine(json); 
            // Prints {"Data":["panel"]}
