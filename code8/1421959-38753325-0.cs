    class Program
    {
        private static IEnumerable<LatLng> GetCoordinates(string polygon)
        {
            var xElement = XElement.Parse(polygon);
            //var innerBoundaryCoordinates = xElement.Elements("innerBoundaryIs").FirstOrDefault()?.Value ?? "";
            var outerBoundaryCoordinates = xElement.Elements("outerBoundaryIs").Single()?.Value ?? "";
            return outerBoundaryCoordinates
                .Split(' ')
                .Select(latLng =>
                {
                    var splits = latLng.Split(',');
                    var lat = double.Parse(splits[0], CultureInfo.InvariantCulture);
                    var lng = double.Parse(splits[1], CultureInfo.InvariantCulture);
                    return new LatLng(lat, lng);
                });
        }
        static void Main()
        {
            const string header = "description,name,label,geometry";
            var latLngs = File.ReadLines("file.csv")
                              .SelectMany(x => x.Split(new[] {header}, StringSplitOptions.RemoveEmptyEntries)) //all geometry`s in one array
                              .Select(x => x.Split('"'))
                              .SelectMany(x => GetCoordinates(x[1]))
                              .ToArray();
        }
    }
