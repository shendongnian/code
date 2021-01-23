        static void Main(string[] args)
         {
            var startPath = Application.StartupPath;
            var city = new City { Tourist = new List<Tourist>() };
            DirectoryInfo d = new DirectoryInfo(startPath+@"\Flensburg\");
            foreach (var file in d.GetFiles())
            {
              using (StreamReader fi = File.OpenText(file.FullName))
              {
                JsonSerializer serializer = new JsonSerializer();
                Tourist tourist = (Tourist)serializer.Deserialize(fi, typeof(Tourist));
                city.Tourist.Add(tourist);
             }
              
            }
            using (StreamWriter file = File.CreateText(@"C:\C# tutorial Backup\joint_josn\joint_josn\bin\Debug\cities.json"))
            {
                JsonSerializer serializer = new JsonSerializer { Formatting = Formatting.Indented };
                serializer.Serialize(file, city);
            }
         
            
          }
