        foreach (var item in json.poi)
        {
            ViewBag.Name = item.Name;
            ViewBag.ShortText = item.Shorttext;
            ViewBag.Latitude = item.Latitude;
            ViewBag.Longitude = item.Longitude;
            ViewBag.Image = item.Image;
        }
