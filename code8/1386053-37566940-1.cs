        var listCoord = new List<Coord>();
        Dictionary<String, string> dict = new Dictionary<string, string>();
        dict.Add("A", "Myvalues");
        listCoord.Add(new Coord
        {
                Segment = "A",
        });
        listCoord.Add(new Coord
        {
          Segment = "B",
        });
        listCoord.Add(new Coord
        {
           Segment = "C",
        });
        List<Coord> result = listCoord.Where(cords => dict.ContainsKey(cords.Segment))
                             .ToList();
