                        string json = file.ReadToEnd();
                        List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.millis);
                        }
