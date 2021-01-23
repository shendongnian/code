     public void ToJsonForLocation(string CityName,string PoiName)
        {
            var startPath = Application.StartupPath;
            string folderName = Path.Combine(startPath, "FinalJson");
            string SubfolderName = Path.Combine(folderName, CityName);
            System.IO.Directory.CreateDirectory(SubfolderName);
            string fileName = PoiName + ".json";
            var path = Path.Combine(SubfolderName, fileName);
            var Jpeg_File = new DirectoryInfo(startPath + @"\Image\" + PoiName).GetFiles("*.jpg");
            POIData Poi=new POIData();
            Poi.Shorttext = File.ReadAllText(startPath + @"\Short Text\" + PoiName + ".txt");
            Poi.GeoCoordinates = GeosFromString(startPath + @"\Latitude Longitude\" + PoiName + ".txt");
            Poi.Images=new List<string> { Jpeg_File[0].Name};
            string json = JsonConvert.SerializeObject(Poi,Formatting.Indented);
            File.WriteAllText(path,json);
        }
