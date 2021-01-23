    public class DocPart
    {
        public string Title { get; set; }
        public bool Checked { get; set; }
    }
    public class DocConfig
    {
        public List<DocPart> Parts { get; set; }
    
        public static DocConfig LoadFromString()
        {
            var config = new DocConfig();
            config.Parts = new List<DocPart>();
            var part1 = new DocPart
            {
                Title = "chapter1",
                Checked = checkBox1.Checked
                
            };
    
            config.Parts.Add(part1);
    
            var part2 = new DocPart
            {
                Title = "chapter2",
                Checked = checkBox2.Checked
    
            };
    
            config.Parts.Add(part2);
    
            var configString = config.SaveToString();
    
            File.WriteAllText(@"d:\temp\test.json", configString);
    
            configString = File.ReadAllText(@"d:\temp\test.json"); 
    
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(configString));
            var serializer = new DataContractJsonSerializer(typeof(DocConfig));
            config = (DocConfig)serializer.ReadObject(ms);
    
            foreach (var part in config.Parts)
            {
                if (part.Title == "chapter1")
                {
                    chekbox1.Checked = part.Checked;
                    Debug.WriteLine("chapter1" + part.Checked);
                }
                if (part.Title == "chapter2")
                {
                    checkbox2.Checked = part.Checked;
                    Debug.WriteLine("chapter2" + part.Checked);
                }
            }
            
            return config;
        } 
    
    
    
        public string SaveToString()
        {
            var serializer = new DataContractJsonSerializer(typeof(DocConfig));
            var ms = new MemoryStream();
            serializer.WriteObject(ms, this);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    
    }
