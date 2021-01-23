    var request = new QueryRockstars { FirstName = "Jimi" };
    //QueryString used:
    Assert.That(request.ToGetUrl(), 
        Is.EqualTo("/adhoc-rockstars?first_name=Jimi"));
    var response = client.Get(request);
    Assert.That(response.Results.Count, Is.EqualTo(1));
    Assert.That(response.Results[0].FirstName, Is.EqualTo("Jimi"));
