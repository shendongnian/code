    string escapedJson = response.Content.ReadAsStringAsync().Result;
    string realJson = JsonConvert.DeserializeObject<string>(escapedJson);
    IEnumerable<MonitorBase> monitors = 
        JsonConvert.DeserializeObject<IEnumerable<MonitorBase>>(realJson, 
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
