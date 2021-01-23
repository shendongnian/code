            var serialize = new Newtonsoft.Json.JsonSerializer();
            using (var sr = new System.IO.StreamWriter("fileName.txt"))
            {
                var dict = GetDic(new Description());
                 serialize.Serialize(sr, dict);
                                  
            }
