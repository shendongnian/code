    Use It.
     public class coordsSample
            {
                public string latitude { get; set; }
                public string longitude { get; set; }
                public int altitude { get; set; }
                public int accuracy { get; set; }
                public int altitudeAccuracy { get; set; }
                public int heading { get; set; }
    
                public int speed { get; set; }
            }
    
            public class coords1
            {
                public coordsSample coords { get; set; }
                public long timestamp { get; set; }
            }
    
      static void Main(string[] args)
            {
                var jsonFormat = @"[{""timestamp"":""1442113213418"",""coords"":{
    ""latitude"":""43.445969749565833"",""longitude"":""-80.484091512936885"",""altitude"":""100"",""accuracy"":""150""
    ,""altitudeAccuracy"":""80"",""heading"":""38"",""speed"":""25""}}]";
                var result = JsonConvert.DeserializeObject<coords1>(jsonFormat.Substring(1).Substring(0, jsonFormat.Length - 2));
    
                Console.WriteLine(result.coords.latitude);
                Console.WriteLine(result.coords.longitude);
    }
