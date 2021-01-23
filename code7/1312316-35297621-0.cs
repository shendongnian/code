        Lit<City> mycities=new List<City>();
         foreach (var item in json.poi)
        {
            City obj=new City(){
            Name = item.Name,
            ShortText = item.Shorttext,
            Latitude = item.Latitude,
            Longitude = item.Longitude,
            Image = item.Image,
             };
           mycities.Add(obj);
        }
