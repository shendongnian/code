    List<double[,]> testChannel = new List<double[,]>();
    for (int i = 0; i < Math.Sqrt(large_mapdata.Length); i+=8) {            
        for (int j = 0; j < Math.Sqrt(large_mapdata.Length); j+=8) {
            testChannel.Add(GetMapSection(new Rectangle(i, j, 8, 8), large_mapdata));
        }
    }
