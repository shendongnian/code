    public class Route
    {
        public string RouteID { get; set; }
        public string DriverName { get; set; }
        public string Shift { get; set; }
    
        public int[][] ItineraryCoordinates;
    
    
        public static string GetSampleJson() {
    
            var sampleRoute = new Route
            {
                RouteID = "123321213312",
                DriverName = "JohnDoe",
                Shift = "Night",
                ItineraryCoordinates = new int[][] { 
                    new int[] {9393, 4443 },
                    new int[] { 8832, 3322 },
                    new int[] {  223, 3432 },
                    new int[] { 223, 3432 }
                }
            };
    
            return JsonConvert.SerializeObject(sampleRoute, Formatting.Indented);
        }
    
        public static string GetSampleJson2()
        {
            var route = new JObject(
                new JProperty("RouteID", "123321213312"),
                new JProperty("DriverName", "JhonDoe"),
                new JProperty("Shift", "Night"),
                new JProperty("ItineraryCoordinates", new JArray(
                        new JArray(9393, 4443),
                        new JArray(8832, 3322 ),
                        new JArray( 223, 3432 ),
                        new JArray( 223, 3432)
                    )
                ));
    
            return route.ToString();
        }
    }
