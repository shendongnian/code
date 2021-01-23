            foreach (var c in myCities)
            {
                DirectoryInfo d = new DirectoryInfo(startPath + @"\" + c);
                var city = new City { Tourists = new List<Tourist>() };
                city.Name = c;
                foreach (var file in d.GetFiles())
                {
                    using (StreamReader fi = File.OpenText(file.FullName)) //getting file not found exception
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        Tourist tourist = (Tourist)serializer.Deserialize(fi, typeof(Tourist));
                        city.Tourists.Add(tourist);
                    }
                }
                cities.Add(city);
            }
            using (StreamWriter file = File.CreateText("output.json"))
