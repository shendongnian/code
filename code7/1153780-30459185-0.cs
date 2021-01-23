    List<string> states = placemarks.Descendants()
    								.Where(x => x.Name.LocalName == "Polygon")
    								.Select(x => x.ToString())
    								.ToList();
    								
    List<string> states = placemarks.Descendants()
    								.Where(x => x.Name.LocalName == "MultiGeometry")
    								.Select(x => x.ToString())
    								.ToList();
