     class Program
        {
            static void Main(string[] args)
            {
                string json = "you json string here";
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<TrackSpotify.RootObject>(json);
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            }
        }    
       
