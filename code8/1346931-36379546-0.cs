        public class VerseObject
        {
     
            [JsonProperty(PropertyName = "en.pickthall")]
            public Dictionary<int, Data> picthall {get;set;}
           
           
        }
        public class Data
        {
            [JsonProperty(PropertyName = "id")]
            public int id;
            [JsonProperty(PropertyName = "surah")]
            public int surah;
            [JsonProperty(PropertyName = "ayah")]
            public int ayah;
            [JsonProperty(PropertyName = "verse")]
            public string verse;
     
        }
     
        class Program
        {
            static void Main(string[] args)
            {
                List<Data> v = new List<Data>();
                using (StreamReader rdr = new StreamReader(@"C:\Temp\en.pickthall.json"))
                {
                    var str = rdr.ReadToEnd();
                    var jsn = JsonConvert.DeserializeObject<VerseObject>(str);
                    foreach(var item in jsn.picthall.Select(x=>x.Value))
                    {
                        v.Add(item);
                    }
                    Console.ReadLine();
                }
            }
       
           
        }
