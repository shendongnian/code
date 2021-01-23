    var str = "{\"identifier\":7,\"name\":\"xyzstr\"}";
                var jsonObject = JsonConvert.DeserializeObject<JObject>(str);
                foreach (var item in jsonObject)
                {
                    Console.WriteLine(item.Key + " " + item.Value.ToString());
                }
                Console.ReadLine();
