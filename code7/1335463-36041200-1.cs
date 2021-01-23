    string T = elemList[0].Attributes["T"].Value;
    string W = elemList[0].Attributes["W"].Value;
    var weather = WeatherFactory.Create(W);
    
    image1.ImageUrl = weather.ImageUrl;
