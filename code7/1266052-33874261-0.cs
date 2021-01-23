    var clientID = "Myclient";
    var clientSecret = "Mysecret";
    
    InstaSharp.InstagramConfig config = new InstaSharp.InstagramConfig(clientID, clientSecret);
    
    var tags = new InstaSharp.Endpoints.Tags(config);
    var result = await tags.Recent("myTag");
    foreach (InstaSharp.Models.Tag item in result.Data)
      {
          MessageBox.Show(...);
      }
