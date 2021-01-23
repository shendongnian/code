    Random rndm = new Random();
    ArrayList CustomList = new ArrayList();
    
    for (int i = 0; i < 10; i++) 
    {
      Point LP = new Point(rndm.Next(50), rndm.Next(50));
      CustomList.Add(LP); 
    }
    var ordered = CustomList.Cast<Point>()
                            .OrderBy(p => p.X)
                            .ThenBy(p => p.Y)
                            .ToList();
