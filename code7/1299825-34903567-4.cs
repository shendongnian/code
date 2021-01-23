    var fileMapper = new Dictionary<string, string>
                        {
                            ["obj"] = "sfsfs",
                            ["obj.attribute"] = "sfsfs"
                        };
    
    
                        var fileLine = new List<string>();
    
                        using (var sr = new StreamReader(fileName))
                        {
                            string line;
    
                            while ((line = sr.ReadLine()) != null; )
                            {
                                var listOfplaceholders = line.GetPlaceHolders();
    
                                var fileResult = new StringBuilder();
    
                                for (var i = 0; i < listOfplaceholders.Count; i++)
                                {
                                    line = line.Replace(listOfplaceholders[i], fileMapper[listOfplaceHolders[i]]));
                                }
    
                                fileLine.Add(line);
                            }
                        }
