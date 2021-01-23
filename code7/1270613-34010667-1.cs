    public class GeometryDto
        {
            public string Type { get; set; }
           
            public double[,] coordinates { get; set; }            
    
        }
    
        class Program
        {
            static void Main()
            {
                var obj = new GeometryDto
                {
                    Type = "Polygon",
                    coordinates = new double[,] { { 319686.3666000003, 7363726.795 }, { 319747.0519000003, 7363778.9233 }, { 5.3434444, 6.423443 }, { 7.2343424234, 8.23424324 } }                     
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                Console.WriteLine(json);
                Console.ReadKey();
            }
        }
