    List<Dictionary<string, deliveryData>> decodedDeliveries = JsonConvert.DeserializeObject<List<Dictionary<string, deliveryData>>>(responseBodyAsText);
    
    foreach (var delivery in decodedDeliveries)
    {
      foreach(var pair in delivery) {
        Console.WriteLine(pair.Key + " : " + pair.Value);
      }
    }
