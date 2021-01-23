    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    class Test
    { 
        static void Main(string[] args) 
        {
            var json = File.ReadAllText("weather.json");
            var root = JsonConvert.DeserializeObject<Root>(json);
            Console.WriteLine(root.Weather[0].Description);
        }
    }
    
    public class Root
    {
        // Just a few of the properties
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public int Visibility { get; set; }
        public string Name { get; set; }
    }
    
    public class Weather
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
