    string json = @"{
      'Name': 'James',
      'Offices': [
        'Auckland',
        'Wellington',
        'Christchurch'
      ]
    }";
    
    UserViewModel model1 = JsonConvert.DeserializeObject<UserViewModel>(json);
    
    foreach (string office in model1.Offices)
    {
        Console.WriteLine(office);
    }
    // Auckland
    // Wellington
    // Christchurch
    // Auckland
    // Wellington
    // Christchurch
    
    UserViewModel model2 = JsonConvert.DeserializeObject<UserViewModel>(json, new JsonSerializerSettings
    {
        ObjectCreationHandling = ObjectCreationHandling.Replace
    });
    foreach (string office in model2.Offices)
    {
        Console.WriteLine(office);
    }
    // Auckland
    // Wellington
    // Christchurch
