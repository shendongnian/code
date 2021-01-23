    static void Main(string[] args)
    {
        string text = "";
        Regex lat = new Regex("Latitude: .+?   (.+)");
        Regex lon = new Regex("Longitude .+?   (.+)");
        using (var streamReader = new StreamReader(@"c:\mb\latlong.txt", Encoding.UTF8))
        {
            string line;
            while ((line = streamReader.ReadLine() != null)
            {
               if (lat.IsMatch(line))
                   lat.Match(line).Groups[1].Value // latitude
               else if(lon.IsMatch(line))
                   lon.Match(line).Groups[1].Value // longitude
            }
        }
        Console.ReadKey();
    }
