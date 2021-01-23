    var clientID = "Myclient";
    var clientSecret = "Mysecret";
    
    InstaSharp.InstagramConfig config = new InstaSharp.InstagramConfig(clientID, clientSecret);
    
    var location = new InstaSharp.Endpoints.Locations(config);
    var result1 = await location.Search(45.759723, 4.842223);
    foreach (InstaSharp.Models.Location l in result1.Result.Data)
    {
        MessageBox.Show(l.Name);
    }
