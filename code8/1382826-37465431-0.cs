           // assuming res is list of objects and RecordId is string not integer/long
            string json = JsonConvert.SerializeObject(res);
            Dictionary<string, res> Dejson = JsonConvert.DeserializeObject<dynamic>(json).ToDictionary(k => k.RecordId, v => v); 
            foreach ((KeyValuePair<string, res> pair in Dejson)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
