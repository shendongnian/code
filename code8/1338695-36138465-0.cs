    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        public class OpenWeatherMapProxy
        {
            public async static Task<RootObject> GetWeather(double lat, double lon)
    
            {
    
                var http = new HttpClient();
    
                var response = await http.GetAsync("http://api.openweathermap.org/data/2.5/weather?lat=35&lon=77.20081&appid=b1b15e88fa797225412429c1c50c122a");
    
    
                var result = await response.Content.ReadAsStringAsync();
    
                var serializer = new DataContractJsonSerializer(typeof(RootObject));
    
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
    
                var data = (RootObject)serializer.ReadObject(ms);
                return data;
    
            }
        }
    
    
        public class Coord
        {
            [DataMember]
            public double lon { get; set; }
            [DataMember]
            public double lat { get; set; }
        }
    
        [DataContract]
        public class Weather
        {
            [DataMember]
            public double id { get; set; }
            [DataMember]
            public string main { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public string icon { get; set; }
        }
    
        [DataContract]
        public class Main
        {
            [DataMember]
            public double temp { get; set; }
            [DataMember]
            public double pressure { get; set; }
            [DataMember]
            public double humidity { get; set; }
            [DataMember]
            public double temp_min { get; set; }
            [DataMember]
            public double temp_max { get; set; }
        }
    
        [DataContract]
        public class Wind
        {
            [DataMember]
            public double speed { get; set; }
            [DataMember]
            public double deg { get; set; }
        }
    
        [DataContract]
        public class Clouds
        {
            [DataMember]
            public double all { get; set; }
        }
    
        [DataContract]
        public class Sys
        {
            [DataMember]
            public double type { get; set; }
            [DataMember]
            public double id { get; set; }
            [DataMember]
            public double message { get; set; }
            [DataMember]
            public string country { get; set; }
            [DataMember]
            public double sunrise { get; set; }
            [DataMember]
            public double sunset { get; set; }
        }
    
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public Coord coord { get; set; }
            [DataMember]
            public List<Weather> weather { get; set; }
            [DataMember]
            public string @base { get; set; }
            [DataMember]
            public Main main { get; set; }
            [DataMember]
            public Wind wind { get; set; }
            [DataMember]
            public Clouds clouds { get; set; }
            [DataMember]
            public double dt { get; set; }
            [DataMember]
            public Sys sys { get; set; }
            [DataMember]
            public double id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public double cod { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                RootObject myWeather = Task.Run(() => OpenWeatherMapProxy.GetWeather(20.0, 30.0)).Result;
                Console.WriteLine( myWeather.name + " - " + ((int)myWeather.main.temp).ToString()); 
            }
    
        }
