                    var stm = new MemoryStream();
                    using (var sw = new StreamWriter(stm))
                    {
                        var ser = new JsonSerializer();
                        ser.Serialize(sw, new Item());
                    }
