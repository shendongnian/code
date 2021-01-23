    using Newtonsoft.Json;
        
    class Program
        {
             public void LoadJson()
            {
                using (StreamReader r = new StreamReader("file.json"))
                {
                    string json = r.ReadToEnd();
                    List<SponsorInfo> items = JsonConvert.DeserializeObject<List<SponsorInfo>>(json);
                }
            }
    
    
            public class SponsorInfo
            {
                public decimal SponsorID { get; set; }
                public decimal FirstBAID { get; set; }
                public decimal SecondBAID { get; set; }
                public decimal ThirdBAID { get; set; }
            }
    
    
    
    
            static void Main(string[] args)
            {
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Console.WriteLine("{0} {1}", item.temp, item.vcc);
                } 
              
            }
    
        }
