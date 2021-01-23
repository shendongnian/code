    public class GeometryDto
        {
            public string Type { get; set; }
           
            public double[,] cordinatestr { get; set; }
            //public List<CoordinateDto> Coordinates { get; set; }
    
        }
    
        class Program
        {
            static void Main()
            {
                var obj = new GeometryDto
                {
                    Type = "Polygon",
                    cordinatestr = new double[,] { { 319686.3666000003, 7363726.795 }, { 319747.0519000003, 7363778.9233 }, { 5, 6 }, { 7, 8 } }  //"[[500,600][700,800]]"
                    //Coordinates = new List<CoordinateDto>() { new CoordinateDto() { X = "[50.5]", Y = "[50.5]" }, new CoordinateDto() { X = "[50.5]", Y = "[50.5]" } }
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                Console.WriteLine(json);
                Console.ReadKey();
            }
        }
