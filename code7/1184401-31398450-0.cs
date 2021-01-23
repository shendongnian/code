                Try this:
                    var t = JsonConvert.DeserializeObject<Request>(JsonConvert.SerializeObject(myObject));
                    foreach (var item in t.numbers)
                    {
                        Console.Write(item.Key);
                        Console.WriteLine(item.Value.date + ":" + item.Value.desc + ":" + item.Value.status);
                    }
