    public class Data
    {
        public string Character { get; set; }
    
        public string[] Numbers { get; set; }
    }
    
    var lines = File.ReadAllLines("filename.txt");
    
    var result = lines.Select(line => 
                              {
                                 var split = x.Split(' '); 
                                 return new Data 
                                 {
                                   Character = split[0], 
                                   Numbers = split[1].Select(c => c.ToString()).ToArray()
                                 }
                              });
